using DnDLibrary.Models;
using DnDPlayerSheet.Models;
using RestSharp;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DnDPlayerSheet.Controllers
{
    public interface IDataProvider
    {
        Task InitializeAsync();
        Task ResetData();

        Task<Spell> GetSpellAsync(int id);

        Task<IEnumerable<Spell>> GetSpellsAsync();

        Task<IEnumerable<Spell>> GetSpellsAsync(Role role, int level);

        Task<Feat> GetFeatAsync(int id);

        Task<IEnumerable<Feat>> GetFeatsAsync();

        Task<IEnumerable<Skill>> GetSkillsAsync();
        Task<CombatAction> GetCombatActionAsync(int id);

        Task<IEnumerable<CombatAction>> GetCombatActionsAsync();

        Task<IEnumerable<CombatAction>> GetCombatActionsAsync(string search);

    }

    public class LocalDataProvider : IDataProvider
    {
        private const string DatabaseFilename = "DnD35.db3";

        private const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        private static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DatabasePath, Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public RestDataProvider RestDataProvider = new RestDataProvider();

        public LocalDataProvider()
        {

        }

        public async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Spell).Name))
                {
                    var result = await Database.CreateTableAsync<Spell>(CreateFlags.ImplicitPK).ConfigureAwait(false);
                    if (result == CreateTableResult.Created)
                    {
                        IEnumerable<Spell> spells = await RestDataProvider.GetSpellsAsync().ConfigureAwait(false);
                        await Database.InsertAllAsync(spells).ConfigureAwait(false);
                    }
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Feat).Name))
                {
                    var result = await Database.CreateTableAsync<Feat>(CreateFlags.ImplicitPK).ConfigureAwait(false);
                    if (result == CreateTableResult.Created)
                    {
                        IEnumerable<Feat> feats = await RestDataProvider.GetFeatsAsync().ConfigureAwait(false);
                        await Database.InsertAllAsync(feats).ConfigureAwait(false);
                    }

                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(CombatAction).Name))
                {
                    var result = await Database.CreateTableAsync<CombatAction>(CreateFlags.ImplicitPK).ConfigureAwait(false);
                    if (result == CreateTableResult.Created)
                    {
                        IEnumerable<CombatAction> combat = await RestDataProvider.GetCombatActionsAsync().ConfigureAwait(false);
                        await Database.InsertAllAsync(combat).ConfigureAwait(false);
                    }
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Skill).Name))
                {
                    var result = await Database.CreateTableAsync<Skill>(CreateFlags.ImplicitPK).ConfigureAwait(false);
                    if (result == CreateTableResult.Created)
                    {
                        IEnumerable<Skill> skills = await RestDataProvider.GetSkillsAsync().ConfigureAwait(false);
                        await Database.InsertAllAsync(skills).ConfigureAwait(false);
                    }
                }
                initialized = true;
            }
        }

        public async Task ResetData()
        {
            List<Task> tasks = new List<Task>()
            {
                Database.DeleteAllAsync<Spell>(),
                Database.DeleteAllAsync<CombatAction>(),
                Database.DeleteAllAsync<Skill>(),
                Database.DeleteAllAsync<Feat>()
            };

            await Task.WhenAll(tasks);
            await Populate();
        }

        private async Task Populate()
        {
            IEnumerable<Spell> spells = await RestDataProvider.GetSpellsAsync().ConfigureAwait(false);
            await Database.InsertAllAsync(spells).ConfigureAwait(false);

            IEnumerable<Feat> feats = await RestDataProvider.GetFeatsAsync().ConfigureAwait(false);
            await Database.InsertAllAsync(feats).ConfigureAwait(false);

            IEnumerable<CombatAction> combat = await RestDataProvider.GetCombatActionsAsync().ConfigureAwait(false);
            await Database.InsertAllAsync(combat).ConfigureAwait(false);

            IEnumerable<Skill> skills = await RestDataProvider.GetSkillsAsync().ConfigureAwait(false);
            await Database.InsertAllAsync(skills).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Spell>> GetSpellsAsync()
        {
            return await Database.Table<Spell>().ToListAsync();
        }

        public async Task<Spell> GetSpellAsync(int id)
        {
            return await Database.Table<Spell>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Spell>> GetSpellsAsync(Role role, int level)
        {
            string r = Conversion.RoleShort(role);
            return await Database.Table<Spell>().Where(x => x.Level.Contains(r + " " + level.ToString())).ToListAsync();
        }

        public async Task<Feat> GetFeatAsync(int id)
        {
            return await Database.Table<Feat>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Feat>> GetFeatsAsync()
        {
            return await Database.Table<Feat>().ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetSkillsAsync()
        {
            return await Database.Table<Skill>().ToListAsync();
        }

        public async Task<CombatAction> GetCombatActionAsync(int id)
        {
            return await Database.Table<CombatAction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CombatAction>> GetCombatActionsAsync()
        {
            return await Database.Table<CombatAction>().ToListAsync();
        }

        public async Task<IEnumerable<CombatAction>> GetCombatActionsAsync(string search)
        {
            return await Database.Table<CombatAction>().Where(x => x.Name.Contains(search)).ToListAsync();
        }
    }

    public class RestDataProvider : IDataProvider
    {
        public RestDataProvider()
        {

        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Feat>> GetFeatsAsync()
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/feats");
            RestRequest request = new RestRequest();
            var response = await client.GetAsync<IEnumerable<Feat>>(request);
            return response;
        }

        public async Task<IEnumerable<CombatAction>> GetCombatActionsAsync()
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/combat");
            RestRequest request = new RestRequest();
            var response = await client.GetAsync<IEnumerable<CombatAction>>(request);
            return response;
        }

        public async Task<IEnumerable<Skill>> GetSkillsAsync()
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/skills");
            RestRequest request = new RestRequest();
            var response = await client.GetAsync<IEnumerable<Skill>>(request);
            return response;
        }

        public async Task<Spell> GetSpellAsync(int id)
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/spells");
            RestRequest request = new RestRequest();
            request.AddParameter("id", id);
            var response = await client.GetAsync<IEnumerable<Spell>>(request);
            return response.First();
        }

        public async Task<IEnumerable<Spell>> GetSpellsAsync()
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/spells");
            RestRequest request = new RestRequest();
            var response = await client.GetAsync<IEnumerable<Spell>>(request).ConfigureAwait(false);
            return response;
        }
        public async Task<IEnumerable<Spell>> GetSpellsAsync(Role role)
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/spells");
            RestRequest request = new RestRequest();
            request.AddParameter("role", role);
            var response = await client.GetAsync<IEnumerable<Spell>>(request);
            return response;
        }

        public async Task<IEnumerable<Spell>> GetSpellsAsync(Role role, int level)
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/spells");
            RestRequest request = new RestRequest();
            request.AddParameter("role", role).AddParameter("level", level);
            var response = await client.GetAsync<IEnumerable<Spell>>(request);
            return response;
        }

        public async Task<Feat> GetFeatAsync(int id)
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/feats");
            RestRequest request = new RestRequest();
            request.AddParameter("id", id);
            var response = await client.GetAsync<IEnumerable<Feat>>(request);
            return response.First();
        }

        public async Task<CombatAction> GetCombatActionAsync(int id)
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/combat");
            RestRequest request = new RestRequest();
            request.AddParameter("id", id);
            var response = await client.GetAsync<IEnumerable<CombatAction>>(request);
            return response.First();
        }

        public async Task<IEnumerable<CombatAction>> GetCombatActionsAsync(string search)
        {
            RestClient client = new RestClient("https://dndwebhelper.azurewebsites.net/api/combat");
            RestRequest request = new RestRequest();
            request.AddParameter("search", search);
            var response = await client.GetAsync<IEnumerable<CombatAction>>(request);
            return response;
        }

        public Task ResetData()
        {
            return Task.CompletedTask;
        }
    }
}

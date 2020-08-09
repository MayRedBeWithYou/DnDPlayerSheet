using DnDLibrary.Models;
using DnDPlayerSheet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDPlayerSheet.Controllers
{
    public static class ModelExtension
    {
        public static void SaveToFile(this Character c)
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string charactersPath = Path.Combine(localPath, "characters");
            File.WriteAllText(Path.Combine(charactersPath, c.Name + ".json"), JsonConvert.SerializeObject(c));
        }
        public static void RemoveFile(this Character c)
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string charactersPath = Path.Combine(localPath, "characters");
            File.Delete(Path.Combine(charactersPath, c.Name + ".json"));
        }

        public static async Task RestoreSpellsAsync(this Character c)
        {
            if (c.SpellIds is null || c.SpellIds.Count == 0) return;
            Spell[] spells = await Task.WhenAll(c.SpellIds.Select(async id => await App.DataProvider.GetSpellAsync(id)))
                                       .ConfigureAwait(false);
            c.Spells = new ObservableCollection<Spell>(spells);
        }
    }
}

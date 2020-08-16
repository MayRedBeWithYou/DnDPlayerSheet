using DnDLibrary.Models;
using DnDPlayerSheet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DnDPlayerSheet.Controllers
{
    public class PlayerController
    {
        public List<Character> Characters { get; } = new List<Character>();

        public Character SelectedCharacter { get; set; }

        public void ClearCharacters()
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string charactersPath = Path.Combine(localPath, "characters");
            string[] files = Directory.GetFiles(charactersPath);
            foreach (string file in files)
            {
                File.Delete(file);                
            }
        }

        public async Task InitCharacters()
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string charactersPath = Path.Combine(localPath, "characters");
            string familiarPath = Path.Combine(localPath, "familiars");

            if (!Directory.Exists(charactersPath)) Directory.CreateDirectory(charactersPath);
            if (!Directory.Exists(familiarPath)) Directory.CreateDirectory(familiarPath);

            Characters.Clear();

            string[] files = Directory.GetFiles(charactersPath);
            foreach (string file in files)
            {
                Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(file));

                await character.RestoreSpellsAsync();
                Characters.Add(character);
            }
            if (Characters.Count == 0)
            {
                Character startCharacter = new Character()
                {
                    Name = "Nowa postać",
                    Alignment = Alignment.TrueNeutral,
                    MaxPW = 10,
                    CurrentPW = 10,
                    Race = "Człowiek",
                    KP = 10,
                    Speed = 9,
                    Touch = 10,
                    Unprepared = 10,
                    Strength = 10,
                    Dexterity = 10,
                    Constitution = 10,
                    Intelligence = 10,
                    Wisdom = 10,
                    Charisma = 10,
                    Fortitude = 0,
                    Will = 0,
                    Reflex = 0,
                    Initiative = 0,
                    MainNotes = "Miejsce na notatki!"
                };
                startCharacter.Classes = new ObservableCollection<ClassLevel>() { new ClassLevel() { Class = Role.Sorcerer, Level = 1 } };
                startCharacter.SpellIds = new ObservableCollection<int>() { };
                startCharacter.SaveToFile();
                Characters.Add(startCharacter);
                SelectedCharacter = startCharacter;
            }
            else SelectedCharacter = Characters[0];

            files = Directory.GetFiles(familiarPath);
            foreach (string file in files)
            {
                //Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(file));
                //Characters.Add(character);
            }

        }
    }
}

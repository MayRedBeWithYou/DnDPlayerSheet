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
                    Name = "Arius",
                    Alignment = Alignment.ChaoticNeutral,
                    MaxPW = 10,
                    CurrentPW = 7,
                    Race = "Tiefling",
                    KP = 12,
                    Speed = 9,
                    Touch = 12,
                    Unprepared = 10,
                    Strength = 8,
                    Dexterity = 12,
                    Constitution = 12,
                    Intelligence = 14,
                    Wisdom = 12,
                    Charisma = 18,
                    Fortitude = 1,
                    Will = 4,
                    Reflex = 1,
                    Initiative = 1,
                    MainNotes = "+1 do pisania kodu\n-69 do połączenia z Internetem"
                };
                startCharacter.Classes = new ObservableCollection<ClassLevel>() { new ClassLevel() { Class = Role.Sorcerer, Level = 2 } };
                startCharacter.SpellIds = new ObservableCollection<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
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

using DnDLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnDPlayerSheet.Controllers
{
    public class PlayerController
    {
        public List<Character> Characters { get; } = new List<Character>();

        public Character SelectedCharacter { get; set; }

        public PlayerController()
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string charactersPath = Path.Combine(localPath, "characters");
            string familiarPath = Path.Combine(localPath, "familiars");

            if (!Directory.Exists(charactersPath)) Directory.CreateDirectory(charactersPath);
            if (!Directory.Exists(familiarPath)) Directory.CreateDirectory(familiarPath);

            string[] files = Directory.GetFiles(charactersPath);
            foreach (string file in files)
            {
                File.Delete(file);
                //Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(file));
                //Characters.Add(character);
            }

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
                Charisma = 18
            };
            startCharacter.Classes = new List<ClassLevel>() { new ClassLevel() { Class = Role.Sorcerer, Level = 2 } };
            startCharacter.SaveToFile();
            Characters.Add(startCharacter);
            SelectedCharacter = startCharacter;

            files = Directory.GetFiles(familiarPath);
            foreach (string file in files)
            {
                //Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(file));
                //Characters.Add(character);
            }
        }
    }
}

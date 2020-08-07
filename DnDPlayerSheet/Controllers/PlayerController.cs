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
                Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(file));
                //Characters.Add(character);
            }

            if (true || Characters.Count == 0)
            {
                Character startCharacter = new Character() { Name = "Postać" };
                startCharacter.Classes = new List<ClassLevel>() { new ClassLevel() { Class = Role.Sorcerer, Level = 4 } };
                startCharacter.SaveToFile();
                Characters.Add(startCharacter);
            }
            SelectedCharacter = Characters[0];

            files = Directory.GetFiles(familiarPath);
            foreach (string file in files)
            {
                //Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(file));
                //Characters.Add(character);
            }
        }
    }
}

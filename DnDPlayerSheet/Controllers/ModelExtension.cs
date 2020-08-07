using DnDLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectB.DAL
{
    public class dataStorageHandler {
        private static string StorageFilelocation { get; set; }
        public static dataStorage storage { get; set; }

        public static void init(string fileName) {
            if(!(File.Exists(fileName))) {
                using StreamWriter sw = File.CreateText(fileName);
                storage = new dataStorage();
            }

            StorageFilelocation = fileName;
            string fileContent = File.ReadAllText(StorageFilelocation);

            try
            {
                storage = JsonConvert.DeserializeObject<dataStorage>(fileContent);
                if(storage == null) { storage = new dataStorage(); }
            }
            catch (Exception)
            {
                storage = new dataStorage();
            }
        }

        public static void saveChanges() {
            string result = JsonConvert.SerializeObject(storage, Formatting.Indented);
            File.WriteAllText(StorageFilelocation, result);
        }
    }
}
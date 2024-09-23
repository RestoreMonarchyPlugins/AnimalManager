using RestoreMonarchy.AnimalManager.Models;
using Rocket.Core.Logging;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestoreMonarchy.AnimalManager.Configurations
{
    public class AnimalSpawnsXmlConfiguration
    {
        private AnimalManagerPlugin pluginInstance => AnimalManagerPlugin.Instance;

        public AnimalSpawnsConfiguration Instance { get; private set; }
        private string fileName => $"AnimalSpawns.{Provider.map}.xml";
        private string filePath => $"{pluginInstance.Directory}/{fileName}";

        private XmlSerializer xmlSerializer = new(typeof(AnimalSpawnsConfiguration), new XmlRootAttribute(nameof(AnimalSpawnsConfiguration)));

        public void Load()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new(filePath))
                {
                    Instance = (AnimalSpawnsConfiguration)xmlSerializer.Deserialize(reader);
                }

                pluginInstance.LogDebug($"Loaded {Instance.AnimalSpawns.Count} airdrop spawns from {fileName}.");
            }
            else
            {
                Instance = Create();
                Save();
                Logger.Log($"Generated {fileName} with {Instance.AnimalSpawns.Count} animal spawns.");
            }
        }

        public void Save()
        {
            using (StreamWriter writer = new(filePath))
            {
                xmlSerializer.Serialize(writer, Instance);
            }

            pluginInstance.LogDebug($"Saved {Instance.AnimalSpawns.Count} animal spawns to {fileName} file.");
        }

        private AnimalSpawnsConfiguration Create()
        {
            AnimalSpawnsConfiguration configuration = new()
            {
                AnimalSpawns = new()
            };

            foreach (var spawn in LevelAnimals.spawns)
            {
                spawn.
            }

            return configuration;
        }
    }
}

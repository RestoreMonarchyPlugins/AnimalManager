using RestoreMonarchy.AnimalButcher.Models;
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
using AnimalSpawn = RestoreMonarchy.AnimalManager.Models.AnimalSpawn;

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

            foreach (AnimalSpawnpoint spawnpoint in LevelAnimals.spawns)
            {
                AnimalTable table = LevelAnimals.tables[spawnpoint.type];
                List<ushort> animalIdsList = new();
                for (int i = 0; i < 100; i++) 
                {
                    animalIdsList.Add(table.getAnimal());
                }

                ushort[] animalIds = animalIdsList.Distinct().ToArray();
                List<string> animalNames = new();
                foreach (ushort animalId in animalIds)
                {
                    if (Assets.find(EAssetType.ANIMAL, animalId) is not AnimalAsset animalAsset)
                    {
                        Logger.LogWarning($"Animal with ID {animalId} not found!");
                        continue;
                    }
                    animalNames.Add(animalAsset.animalName);
                }

                AnimalSpawn animalSpawn = new()
                {
                    AnimalId = animalIdsList.Distinct().ToArray(),
                    Name = string.Join(", ", animalNames),
                    Position = new(spawnpoint.point)
                };
                configuration.AnimalSpawns.Add(animalSpawn);
            }

            return configuration;
        }
    }
}

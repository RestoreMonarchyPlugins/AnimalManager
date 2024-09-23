using RestoreMonarchy.AnimalManager.Models;
using Rocket.API;
using System;
using System.Linq;
using System.Xml.Serialization;

namespace RestoreMonarchy.AnimalManager
{
    public class AnimalManagerConfiguration : IRocketPluginConfiguration
    {
        public bool Debug { get; set; }
        public bool ShouldSerializeDebug() => Debug;
        public string MessageColor { get; set; }
        public CustomSpawnsConfig CustomSpawns { get; set; }
        [XmlArrayItem("Animal")]
        public AnimalConfig[] Animals { get; set; }

        public void LoadDefaults()
        {
            MessageColor = "yellow";
            CustomSpawns = new()
            {
                Enabled = true,
                DefaultRespawnTime = 300,
                DefaultMaxRadius = 1024,
                BlockUnderwater = true
            };
            Animals = 
            [
                new() 
                {
                    Id = 1,
                    Name = "Deer",
                    LootItems =
                    [
                        new(514, Guid.Empty, "Raw Venison", 1, 3),
                        new(516, Guid.Empty, "Leather", 2, 5)
                    ]
                },
                new()
                {
                    Id = 2,
                    Name = "Moose",
                    LootItems =
                    [
                        new(514, Guid.Empty, "Raw Venison", 1, 3),
                        new(516, Guid.Empty, "Leather", 2, 5)
                    ]
                },
                new()
                {
                    Id = 3,
                    Name = "Wolf",
                    LootItems =
                    [
                        new(514, Guid.Empty, "Raw Venison", 1, 2),
                        new(516, Guid.Empty, "Leather", 1, 3)
                    ]
                },
                new()
                {
                    Id = 4,
                    Name = "Pig",
                    LootItems =
                    [
                        new(1117, Guid.Empty, "Pork", 1, 2),
                        new(516, Guid.Empty, "Leather", 1, 3)
                    ]
                },
                new() 
                {
                    Id = 5,
                    Name = "Bear",
                    LootItems =
                    [
                        new(514, Guid.Empty, "Raw Venison", 2, 4),
                        new(516, Guid.Empty, "Leather", 3, 6)
                    ]
                },
                new()
                {
                    Id = 6,
                    Name = "Cow",
                    LootItems =
                    [
                        new(1120, Guid.Empty, "Raw Beef", 1, 2),
                        new(462, Guid.Empty, "Milk Box", 1, 2),
                        new(516, Guid.Empty, "Leather", 2, 5)
                    ]
                },
                new()
                {
                    Id = 7,
                    Name = "Reindeer",
                    LootItems =
                    [
                        new(514, Guid.Empty, "Raw Venison", 1, 3),
                        new(516, Guid.Empty, "Leather", 2, 5)
                    ]
                },
            ];
        }

        public AnimalConfig GetAnimalById(ushort animalId)
        {
            return Animals.FirstOrDefault(x => x.Id == animalId);
        }
    }
}

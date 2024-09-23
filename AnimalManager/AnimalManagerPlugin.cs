using HarmonyLib;
using RestoreMonarchy.AnimalManager.Configurations;
using RestoreMonarchy.AnimalManager.Helpers;
using RestoreMonarchy.AnimalManager.Models;
using RestoreMonarchy.AnimalManager.Services;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using UnityEngine;
using AnimalSpawn = RestoreMonarchy.AnimalManager.Models.AnimalSpawn;
using Logger = Rocket.Core.Logging.Logger;

namespace RestoreMonarchy.AnimalManager
{
    public class AnimalManagerPlugin : RocketPlugin<AnimalManagerConfiguration>
    {
        public static AnimalManagerPlugin Instance { get; private set; }

        public AnimalSpawnsXmlConfiguration AnimalSpawnsConfiguration { get; private set; }
        public AnimalSpawnService AnimalSpawnService { get; private set; }

        public const string HarmonyId = "com.restoremonarchy.animalmanager";
        private Harmony harmony;

        protected override void Load()
        {
            Instance = this;

            AnimalSpawnsConfiguration = new();

            harmony = new Harmony(HarmonyId);
            harmony.PatchAll();

            if (Level.isLoaded)
            {
                OnPostLevelLoaded(0);
            } else
            {
                Level.onPostLevelLoaded += OnPostLevelLoaded;
            }

            Logger.Log($"{Name} {Assembly.GetName().Version.ToString(3)} has been loaded!", ConsoleColor.Yellow);
            Logger.Log("Check out more Unturned plugins at restoremonarchy.com");
        }

        protected override void Unload()
        {
            Level.onPostLevelLoaded -= OnPostLevelLoaded;

            Destroy(AnimalSpawnService);

            Logger.Log($"{Name} has been unloaded!", ConsoleColor.Yellow);
        }

        internal void LogDebug(string message)
        {
            if (Configuration.Instance.Debug)
            {
                Logger.Log($"Debug >> {message}", ConsoleColor.Gray);
            }
        }

        private void OnPostLevelLoaded(int level)
        { 
            AnimalSpawnsConfiguration.Load();
            AnimalHelper.ResetAnimalManager();
            AnimalSpawnService = gameObject.AddComponent<AnimalSpawnService>();
        }

        public float GetRadius(AnimalSpawn animalSpawn)
        {
            if (animalSpawn.Radius > 0)
            {
                return animalSpawn.Radius;
            }

            return Configuration.Instance.DefaultRadius;
        }

        public float GetRespawnTime(AnimalSpawn animalSpawn)
        {
            if (animalSpawn.RespawnTime > 0)
            {
                return animalSpawn.RespawnTime;
            }

            return Configuration.Instance.DefaultRespawnTime;
        }

        public bool DropLoot(Animal animal)
        {
            AnimalConfig animalConfig = Configuration.Instance.GetAnimalById(animal.asset.id);
            if (animalConfig == null)
            {
                return false;
            }

            if (animalConfig.LootItems == null)
            {
                return false;
            }

            Vector3 position = animal.transform.position;
            foreach (LootItem lootItem in animalConfig.LootItems)
            {
                byte amount = (byte)UnityEngine.Random.Range(lootItem.Min, lootItem.Max + 1);
                if (amount == 0)
                {
                    continue;
                }

                ItemAsset itemAsset = Assets.find(EAssetType.ITEM, lootItem.Id) as ItemAsset;
                for (byte i = 0; i < amount; i++)
                {
                    Item item = new(itemAsset, EItemOrigin.NATURE);

                    ItemManager.dropItem(item, position, false, true, true);
                }
            }

            return true;
        }
    }
}
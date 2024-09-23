using HarmonyLib;
using RestoreMonarchy.AnimalManager.Configurations;
using RestoreMonarchy.AnimalManager.Helpers;
using RestoreMonarchy.AnimalManager.Models;
using RestoreMonarchy.AnimalManager.Services;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
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
        public Color MessageColor { get; private set; }

        public AnimalSpawnsXmlConfiguration AnimalSpawnsConfiguration { get; private set; }
        public AnimalSpawnService AnimalSpawnService { get; private set; }

        public const string HarmonyId = "com.restoremonarchy.animalmanager";
        private Harmony harmony;

        protected override void Load()
        {
            Instance = this;
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, Color.green);

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

        public override TranslationList DefaultTranslations => new()
        {
            { "SetAnimalSpawnSyntax", "/setanimalspawn <animal> [maxRadius] [respawnTime]" },
            { "AnimalNotFound", "Animal {0} not found." },
            { "InvalidRadius", "Invalid radius: {0}" },
            { "InvalidRespawnTime", "Invalid respawn time: {0}" },
            { "AnimalSpawnSet", "Animal spawn for {0} has been set at {1}!" },
            { "NoAnimalSpawnsFound", "No animal spawns found in radius of {0}." },
            { "AnimalSpawnRemoved", "Found and removed {0} animal spawns in {1}m radius." },
            { "AnimalsNone", "There isn't any alive animals on the map." },
            { "AnimalsNoneSpecific", "There isn't any alive {0} animals on the map." },            
            { "AnimalTeleported", "You have been teleported to {0} animal." }
        };

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
            if (Configuration.Instance.CustomSpawns.Enabled)
            {
                AnimalHelper.ResetAnimalManager();
                AnimalSpawnService = gameObject.AddComponent<AnimalSpawnService>();
            }            
        }

        public float GetRadius(AnimalSpawn animalSpawn)
        {
            if (animalSpawn.MaxRadius > 0)
            {
                return animalSpawn.MaxRadius;
            }

            return Configuration.Instance.CustomSpawns.DefaultMaxRadius;
        }

        public float GetRespawnTime(AnimalSpawn animalSpawn)
        {
            if (animalSpawn.RespawnTime > 0)
            {
                return animalSpawn.RespawnTime;
            }

            return Configuration.Instance.CustomSpawns.DefaultRespawnTime;
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
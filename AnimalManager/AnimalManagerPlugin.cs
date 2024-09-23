using RestoreMonarchy.AnimalManager.Configurations;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;

namespace RestoreMonarchy.AnimalManager
{
    public class AnimalManagerPlugin : RocketPlugin<AnimalManagerConfiguration>
    {
        public static AnimalManagerPlugin Instance { get; private set; }

        public AnimalSpawnsXmlConfiguration AnimalSpawnsConfiguration { get; private set; }

        protected override void Load()
        {
            Instance = this;

            AnimalSpawnsConfiguration = new();

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
        }
    }
}
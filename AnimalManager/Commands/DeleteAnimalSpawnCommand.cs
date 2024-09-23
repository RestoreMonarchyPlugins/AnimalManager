using RestoreMonarchy.AnimalManager.Models;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using AnimalSpawn = RestoreMonarchy.AnimalManager.Models.AnimalSpawn;

namespace RestoreMonarchy.AnimalManager.Commands
{
    public class DeleteAnimalSpawnCommand : IRocketCommand
    {
        private AnimalManagerPlugin pluginInstance => AnimalManagerPlugin.Instance;

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            float radius = 10;
            if (command.Length > 0 && !float.TryParse(command[0], out radius))
            {
                UnturnedChat.Say(caller, pluginInstance.Translate("InvalidRadius", command[0]), pluginInstance.MessageColor);
                return;
            }

            List<AnimalSpawn> animalSpawns = pluginInstance.AnimalSpawnsConfiguration.Instance.AnimalSpawns
                .Where(x => Vector3.Distance(player.Position, new(x.X, x.Y, x.Z)) <= radius)
                .ToList();

            if (animalSpawns.Count == 0)
            {
                UnturnedChat.Say(caller, pluginInstance.Translate("NoAnimalSpawnsFound", radius), pluginInstance.MessageColor);
                return;
            }

            foreach (AnimalSpawn animalSpawn in animalSpawns)
            {
                pluginInstance.AnimalSpawnsConfiguration.Instance.AnimalSpawns.Remove(animalSpawn);
                if (pluginInstance.AnimalSpawnService != null)
                {
                    pluginInstance.AnimalSpawnService.DeactiveAnimalSpawn(animalSpawn);
                }                
            }

            pluginInstance.AnimalSpawnsConfiguration.Save();

            UnturnedChat.Say(caller, pluginInstance.Translate("AnimalSpawnRemoved", animalSpawns.Count, radius), pluginInstance.MessageColor);
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "deleteanimalspawn";

        public string Help => "";

        public string Syntax => "[radius]";

        public List<string> Aliases => new();

        public List<string> Permissions => new();
    }
}

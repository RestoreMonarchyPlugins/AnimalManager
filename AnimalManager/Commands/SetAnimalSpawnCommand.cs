using RestoreMonarchy.AnimalManager.Helpers;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;
using AnimalSpawn = RestoreMonarchy.AnimalManager.Models.AnimalSpawn;

namespace RestoreMonarchy.AnimalManager.Commands
{
    public class SetAnimalSpawnCommand : IRocketCommand
    {
        private AnimalManagerPlugin pluginInstance => AnimalManagerPlugin.Instance;

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, pluginInstance.Translate("SetAnimalSpawnSyntax"), pluginInstance.MessageColor);
                return;
            }

            AnimalAsset animalAsset = AnimalHelper.GetAnimalByNameOrId(command[0]);

            if (animalAsset == null)
            {
                UnturnedChat.Say(caller, pluginInstance.Translate("AnimalNotFound"), pluginInstance.MessageColor);
                return;
            }

            float radius = 0;
            if (command.Length > 1 && !float.TryParse(command[1], out radius))
            {
                UnturnedChat.Say(caller, pluginInstance.Translate("InvalidRadius", command[1]), pluginInstance.MessageColor);
                return;
            }

            uint respawnTime = 0;
            if (command.Length > 2 && !uint.TryParse(command[2], out respawnTime))
            {
                UnturnedChat.Say(caller, pluginInstance.Translate("InvalidRespawnTime", command[2]), pluginInstance.MessageColor);
                return;
            }

            AnimalSpawn animalSpawn = new()
            {
                Name = animalAsset.animalName,
                AnimalId = [animalAsset.id],
                MaxRadius = radius,
                RespawnTime = respawnTime,
                X = player.Position.x,
                Y = player.Position.y,
                Z = player.Position.z
            };

            pluginInstance.AnimalSpawnsConfiguration.Instance.AnimalSpawns.Add(animalSpawn);
            pluginInstance.AnimalSpawnsConfiguration.Save();

            if (pluginInstance.AnimalSpawnService != null)
            {
                pluginInstance.AnimalSpawnService.ActiveAnimalSpawn(animalSpawn);
            }

            string positionString = (new Vector3(animalSpawn.X, animalSpawn.Y, animalSpawn.Z)).ToString();
            UnturnedChat.Say(caller, pluginInstance.Translate("AnimalSpawnSet", animalAsset.FriendlyName, positionString), pluginInstance.MessageColor);
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "setanimalspawn";

        public string Help => "";

        public string Syntax => "<animal> [radius] [respawnTime]";

        public List<string> Aliases => new();

        public List<string> Permissions => new();
    }
}

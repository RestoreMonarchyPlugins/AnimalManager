using RestoreMonarchy.AnimalManager.Helpers;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using System.Linq;

namespace RestoreMonarchy.AnimalManager.Commands
{
    public class TPAnimalCommand : IRocketCommand
    {
        private AnimalManagerPlugin pluginInstance => AnimalManagerPlugin.Instance;

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            List<Animal> animals = SDG.Unturned.AnimalManager.animals.Where(x => !x.isDead).ToList();
            if (SDG.Unturned.AnimalManager.animals.Count == 0)
            {
                UnturnedChat.Say(caller, pluginInstance.Translate("AnimalsNone"), pluginInstance.MessageColor);
                return;
            }

            Animal animal;
            if (command.Length > 0)
            {
                AnimalAsset animalAsset = AnimalHelper.GetAnimalByNameOrId(command[0]);
                if (animalAsset == null)
                {
                    UnturnedChat.Say(caller, pluginInstance.Translate("AnimalNotFound", command[0]), pluginInstance.MessageColor);
                    return;
                }

                animals = animals.Where(x => x.asset.id == animalAsset.id).ToList();

                if (animals.Count == 0)
                {
                    UnturnedChat.Say(caller, pluginInstance.Translate("AnimalsNoneSpecific", animalAsset.animalName), pluginInstance.MessageColor);
                    return;
                }
            }

            animal = animals[UnityEngine.Random.Range(0, animals.Count)];

            // teleport player to animal
            player.Player.teleportToLocationUnsafe(animal.transform.position, player.Player.look.yaw);
            UnturnedChat.Say(player, pluginInstance.Translate("AnimalTeleported", animal.asset.animalName), pluginInstance.MessageColor);
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "tpanimal";

        public string Help => "Teleports you to the random animal";

        public string Syntax => "";

        public List<string> Aliases => new();

        public List<string> Permissions => new();
    }
}

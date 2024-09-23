using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoreMonarchy.AnimalManager.Commands
{
    public class TPAnimalCommand : IRocketCommand
    {
        private readonly AnimalManagerPlugin pluginInstance;

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            List<Animal> animals = SDG.Unturned.AnimalManager.animals.Where(x => !x.isDead).ToList();
            if (SDG.Unturned.AnimalManager.animals.Count == 0)
            {
                UnturnedChat.Say("There are no animals on the map.", UnityEngine.Color.red);
                return;
            }

            // get random animal from SDG.Unturned.AnimalManager.animals

            Animal animal = animals[UnityEngine.Random.Range(0, animals.Count)];

            // teleport player to animal

            player.Player.teleportToLocationUnsafe(animal.transform.position, player.Player.look.yaw);
            UnturnedChat.Say(player, $"Teleported to {animal.asset.name}", UnityEngine.Color.yellow);
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "tpanimal";

        public string Help => "Teleports you to the random animal";

        public string Syntax => "";

        public List<string> Aliases => new();

        public List<string> Permissions => new();
    }
}

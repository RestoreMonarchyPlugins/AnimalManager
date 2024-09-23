using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoreMonarchy.AnimalManager.Commands
{
    public class SetAnimalSpawnCommand : IRocketCommand
    {
        private AnimalManagerPlugin pluginInstance => AnimalManagerPlugin.Instance;

        public void Execute(IRocketPlayer caller, string[] command)
        {

        }

        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "setanimalspawn";

        public string Help => "";

        public string Syntax => "<animal> [radius] [respawnTime]";

        public List<string> Aliases => new();

        public List<string> Permissions => new();
    }
}

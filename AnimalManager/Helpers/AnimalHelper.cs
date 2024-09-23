using SDG.Unturned;
using System.Collections.Generic;

namespace RestoreMonarchy.AnimalManager.Helpers
{
    internal static class AnimalHelper
    {
        internal static void ResetAnimalManager()
        {
            SDG.Unturned.AnimalManager.askClearAllAnimals();
            SDG.Unturned.AnimalManager.animals.Clear();
            SDG.Unturned.AnimalManager.packs.Clear();
            SDG.Unturned.AnimalManager.tickingAnimals.Clear();
        }

        internal static AnimalAsset GetAnimalByNameOrId(string name)
        {
            List<AnimalAsset> assets = new();
            Assets.find(assets);

            AnimalAsset animalAsset = null;
            foreach (AnimalAsset asset in assets)
            {
                if (asset != null && 
                    asset.id.ToString() == name 
                    || (asset.FriendlyName != null && asset.FriendlyName.ToLower().Contains(name.ToLower())))
                {
                    animalAsset = asset;
                    break;
                }
            }

            return animalAsset;
        }
    }
}

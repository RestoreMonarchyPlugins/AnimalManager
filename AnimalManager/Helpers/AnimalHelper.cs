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
    }
}

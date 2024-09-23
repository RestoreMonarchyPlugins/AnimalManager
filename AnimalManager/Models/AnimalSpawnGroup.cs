using SDG.Unturned;
using UnityEngine;
using AnimalSpawn = RestoreMonarchy.AnimalManager.Models.AnimalSpawn;

namespace RestoreMonarchy.AnimalManager.Models
{
    public class AnimalSpawnGroup
    {
        public AnimalSpawn Spawn { get; set; }
        public Animal Animal { get; set; }
        public Coroutine Coroutine { get; set; }
    }
}

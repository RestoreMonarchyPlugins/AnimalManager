using SDG.Framework.Water;
using SDG.Unturned;
using UnityEngine;
using AnimalSpawn = RestoreMonarchy.AnimalManager.Models.AnimalSpawn;

namespace RestoreMonarchy.AnimalManager.Components
{
    public class AnimalComponent : MonoBehaviour
    {
        private AnimalManagerPlugin pluginInstance => AnimalManagerPlugin.Instance;

        public Animal Animal { get; private set; }

        public AnimalSpawn AnimalSpawn { get; internal set; }
        public Vector3 AnimalSpawnPosition { get; set; }

        void Awake()
        {
            Animal = GetComponent<Animal>();

        }

        internal void SetAnimalSpawn(AnimalSpawn animalSpawn)
        {
            AnimalSpawn = animalSpawn;
            AnimalSpawnPosition = new(animalSpawn.X, animalSpawn.Y, animalSpawn.Z);
        }

        void Start()
        {
            InvokeRepeating(nameof(CheckPosition), 1, 1);
        }

        void OnDestroy()
        {
            CancelInvoke(nameof(CheckPosition));
        }

        private void CheckPosition()
        {
            if (Animal.isDead)
            {
                return;
            }

            float radius = pluginInstance.GetRadius(AnimalSpawn);
            if (radius > 0 && !Animal.isHunting)
            {
                float distance = Vector3.Distance(Animal.transform.position, AnimalSpawnPosition);

                if (distance > radius)
                {
                    Animal.alertGoToPoint(AnimalSpawnPosition, true);
                }
            }

            bool isUnderwater = WaterUtility.isPointUnderwater(Animal.transform.position);
            if (isUnderwater)
            {
                Animal.alertGoToPoint(AnimalSpawnPosition, true);
            }
        }
    }
}

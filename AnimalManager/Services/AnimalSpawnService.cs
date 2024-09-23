using SDG.Unturned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RestoreMonarchy.AnimalManager.Services
{
    public class AnimalSpawnService
    {
        void Start()
        {
            SDG.Unturned.AnimalManager.spawnAnimal()
        }

        void OnDestroy()
        {

        }

        private IEnumerator AnimalSpawnCoroutine(AnimalSpawnData animalSpawn)
        {
            Vector3 position = animalSpawn.Position.ToVector3();
            Quaternion quaternion = Quaternion.Euler(0, animalSpawn.Angle * 2, 0);

            while (true)
            {
                SDG.Unturned.AnimalManager.spawnAnimal(animalSpawn.AnimalId, position, quaternion);
                List<Animal> animalsInRadius = [];
                SDG.Unturned.AnimalManager.getAnimalsInRadius(position, 0.01f, animalsInRadius);
                Animal animal = animalsInRadius.FirstOrDefault(x => x.id == animalSpawn.AnimalId);

                if (animal == null)
                {
                    pluginInstance.LogError("Animal {0} not found", animalSpawn.AnimalId);
                    yield break;
                }

                AnimalComponent animalComponent = animal.gameObject.GetComponent<AnimalComponent>();
                if (animalComponent == null)
                {
                    animalComponent = animal.gameObject.AddComponent<AnimalComponent>();
                }

                animalComponent.OriginalPosition = position;
                animalComponent.Radius = (float)animalSpawn.Radius;

                spawnedAnimals[animalSpawn.Name] = animal;

                while (true)
                {
                    yield return new WaitForSeconds(5);

                    if (animal.isDead)
                    {
                        break;
                    }
                }

                yield return new WaitForSeconds(animalSpawn.RespawnTime);
            }
        }
    }
}

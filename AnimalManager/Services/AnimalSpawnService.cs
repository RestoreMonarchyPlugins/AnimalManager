using RestoreMonarchy.AnimalManager.Components;
using RestoreMonarchy.AnimalManager.Models;
using SDG.Unturned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AnimalSpawn = RestoreMonarchy.AnimalManager.Models.AnimalSpawn;
using Logger = Rocket.Core.Logging.Logger;
using Random = UnityEngine.Random;

namespace RestoreMonarchy.AnimalManager.Services
{
    public class AnimalSpawnService : MonoBehaviour
    {
        private AnimalManagerPlugin pluginInstance => AnimalManagerPlugin.Instance;
        private AnimalManagerConfiguration configuration => pluginInstance.Configuration.Instance;
        private AnimalSpawnsConfiguration spawnsConfiguration => pluginInstance.AnimalSpawnsConfiguration.Instance;

        private readonly List<AnimalSpawnGroup> animalSpawnGroups = new();

        void Start()
        {
            foreach (AnimalSpawn animalSpawn in pluginInstance.AnimalSpawnsConfiguration.Instance.AnimalSpawns)
            {
                ActiveAnimalSpawn(animalSpawn);
            }
        }

        void OnDestroy()
        {
            foreach (AnimalSpawnGroup spawnGroup in animalSpawnGroups.ToList())
            {
                DeactiveAnimalSpawn(spawnGroup);
            }
        }

        public void ActiveAnimalSpawn(AnimalSpawn animalSpawn)
        {
            AnimalSpawnGroup spawnGroup = new()
            {
                Spawn = animalSpawn
            };

            spawnGroup.Coroutine = StartCoroutine(AnimalSpawnCoroutine(spawnGroup));
            animalSpawnGroups.Add(spawnGroup);
        }

        public void DeactiveAnimalSpawn(AnimalSpawnGroup spawnGroup)
        {
            StopCoroutine(spawnGroup.Coroutine);
            if (spawnGroup.Animal != null && !spawnGroup.Animal.isDead)
            {
                spawnGroup.Animal.askDamage(ushort.MaxValue, Vector3.up, out var _, out var _, false, false, ERagdollEffect.NONE);
            }
            SDG.Unturned.AnimalManager.animals.Remove(spawnGroup.Animal);
            Destroy(spawnGroup.Animal);
            animalSpawnGroups.Remove(spawnGroup);
        }

        private IEnumerator AnimalSpawnCoroutine(AnimalSpawnGroup spawnGroup)
        {
            AnimalSpawn animalSpawn = spawnGroup.Spawn;
            Vector3 position = new(animalSpawn.X, animalSpawn.Y, animalSpawn.Z);
            float angle = Random.Range(0, 360);
            Quaternion quaternion = Quaternion.Euler(0, angle * 2, 0);

            ushort animalId = animalSpawn.AnimalId[Random.Range(0, animalSpawn.AnimalId.Length)];
            SDG.Unturned.AnimalManager.spawnAnimal(animalId, position, quaternion);
            List<Animal> animalsInRadius = [];
            SDG.Unturned.AnimalManager.getAnimalsInRadius(position, 0.01f, animalsInRadius);
            Animal animal = animalsInRadius.FirstOrDefault(x => x.id == animalId && x.GetComponent<AnimalComponent>() == null);

            if (animal == null)
            {
                Logger.LogWarning($"Animal {animalId} not found");
                yield break;
            }

            AnimalComponent animalComponent = animal.gameObject.GetComponent<AnimalComponent>();
            if (animalComponent == null)
            {
                animalComponent = animal.gameObject.AddComponent<AnimalComponent>();
            }

            animalComponent.AnimalSpawn = animalSpawn;

            animalSpawnGroups.FirstOrDefault(x => x.Spawn == animalSpawn);
            spawnGroup.Animal = animal;

            while (true)
            {
                while (true)
                {
                    yield return new WaitForSeconds(1);

                    if (animal.isDead)
                    {
                        break;
                    }
                }

                float respawnTime = pluginInstance.GetRespawnTime(animalSpawn);
                yield return new WaitForSeconds(respawnTime);
                if (spawnGroup.Animal == null)
                {
                    Logger.Log($"Animal {animalId} is null", ConsoleColor.Yellow);
                    yield break;
                } else
                {
                    spawnGroup.Animal.sendRevive(position, angle);
                }                
            }
        }
    }
}

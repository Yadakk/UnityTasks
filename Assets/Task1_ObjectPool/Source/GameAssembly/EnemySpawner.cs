using Codice.Client.Common.GameUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class EnemySpawner : MonoBehaviour
    {
        private readonly Queue<Enemy> enemies = new();

        [SerializeField]
        private Prototype prototype;

        [SerializeField]
        private int maxEnemies = 10;

        private Mode mode;

        private enum Mode
        {
            Spawning,
            Despawning,
        }

        void Start()
        {
            SpawnThenDespawnEnemies();
        }

        private void SpawnThenDespawnEnemies()
        {
            StartCoroutine(Routine());

            IEnumerator Routine()
            {
                while (true)
                {
                    switch(mode)
                    {
                        case Mode.Spawning: Spawn(); break;
                        case Mode.Despawning: Despawn(); break;
                    }

                    CheckModeChange();

                    yield return new WaitForSeconds(1f);
                }
            }
        }

        private void CheckModeChange()
        {
            if (enemies.Count == 0)
                mode = Mode.Spawning;
            else if (enemies.Count == maxEnemies)
                mode = Mode.Despawning;
        }

        private void Spawn()
        {
            var enemy = prototype.Instantiate<Enemy>();
            enemies.Enqueue(enemy);
            enemy.Say("Hello");
        }

        private void Despawn()
        {
            var enemy = enemies.Dequeue();
            enemy.Say("Goodbye");
            enemy.ReturnToPool();
        }
    }
}

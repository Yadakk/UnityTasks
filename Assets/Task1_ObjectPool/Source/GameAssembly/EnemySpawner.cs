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

        void Start()
        {
            InvokeRepeating(nameof(Spawn), 0f, 1f);
        }

        private void Spawn()
        {
            if (enemies.Count == maxEnemies)
            {
                CancelInvoke(nameof(Spawn));
                InvokeRepeating(nameof(Despawn), 0f, 1f);
                return;
            }

            var enemy = prototype.Instantiate<Enemy>();
            enemies.Enqueue(enemy);
            enemy.Say("Hello");
        }

        private void Despawn()
        {
            if (enemies.Count == 0)
            {
                CancelInvoke(nameof(Despawn));
                InvokeRepeating(nameof(Spawn), 0f, 1f);
                return;
            }

            var enemy = enemies.Dequeue();
            enemy.Say("Goodbye");
            enemy.ReturnToPool();
        }
    }
}

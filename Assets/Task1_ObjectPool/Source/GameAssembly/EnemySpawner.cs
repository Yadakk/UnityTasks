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

        public void Spawn()
        {
            var enemy = prototype.Instantiate<Enemy>();
            enemies.Enqueue(enemy);
            enemy.Say("Hello");
        }

        public void Despawn()
        {
            if (enemies.Count == 0) return;
            var enemy = enemies.Dequeue();
            enemy.Say("Goodbye");
            enemy.ReturnToPool();
        }
    }
}

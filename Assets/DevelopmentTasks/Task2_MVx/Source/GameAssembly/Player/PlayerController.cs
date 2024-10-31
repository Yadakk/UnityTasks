using MVxTask.Tickables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVxTask.Player
{
    public class PlayerController : ITickable
    {
        private readonly PlayerModel model;
        private readonly Settings settings;

        private Vector2 direction;

        public PlayerController(Settings settings)
        {
            model.Move(direction);
        }

        public void Tick()
        {
            Move();
        }

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        private void Move()
        {
            model.Move(direction * settings.Speed);
        }

        [System.Serializable]
        public struct Settings
        {
            [field: SerializeField]
            public float Speed { get; private set; }
        }
    }
}

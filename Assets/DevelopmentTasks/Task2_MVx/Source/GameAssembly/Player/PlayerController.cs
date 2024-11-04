using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVxTask.Player
{
    public class PlayerController
    {
        private readonly Settings settings;
        private readonly PlayerModel model;
        private readonly PlayerView view;

        private Vector2 direction;

        public PlayerController(Settings settings, PlayerModel model, PlayerView view)
        {
            this.settings = settings;

            this.model = model;
            model.OnHealthDepleted += OnHealthDepletedHandler;

            this.view = view;
            view.OnDamaged += model.Damage;
        }

        public void Tick()
        {
            model.SetVelocity(direction * settings.Speed);
        }

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        private void OnHealthDepletedHandler()
        {
            Object.Destroy(view.gameObject);
        }

        [System.Serializable]
        public struct Settings
        {
            [field: SerializeField]
            public float Speed { get; private set; }
        }
    }
}

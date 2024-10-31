using MVxTask.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVxTask.Player
{
    public class PlayerModel : IHealth
    {
        private readonly Settings settings;
        private readonly PlayerView view;

        private float currentHealth;
        private Vector2 position;

        public float MaxHealth => settings.MaxHealth;

        public event System.Action OnHealthChanged;
        public event System.Action OnHealthDepleted;

        public PlayerModel(Settings settings, PlayerView view)
        {
            this.settings = settings;
            this.view = view;
            SetPosition(view.transform.position);
        }

        public float CurrentHealth 
        { 
            get => currentHealth; 
            set
            {
                if (value == currentHealth) return;
                currentHealth = value;
                OnHealthChanged?.Invoke();
                if (currentHealth <= 0) OnHealthDepleted?.Invoke();
            }
        }

        public void Damage(float damage)
        {
            CurrentHealth -= damage;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
            view.ViewPosition(this.position);
        }

        public void Move(Vector2 offset)
        {
            SetPosition(position + offset);
        }

        [System.Serializable]
        public struct Settings
        {
            [field: SerializeField]
            public float MaxHealth { get; private set; }
        }
    }
}

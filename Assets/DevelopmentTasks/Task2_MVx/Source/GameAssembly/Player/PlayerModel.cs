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

        public float MaxHealth => settings.MaxHealth;

        public event System.Action OnHealthChanged;
        public event System.Action OnHealthDepleted;

        public PlayerModel(Settings settings, PlayerView view)
        {
            this.settings = settings;
            this.view = view;
            CurrentHealth = MaxHealth;
            UpdateColor();
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
            UpdateColor();
        }

        private void UpdateColor()
        {
            view.SetColor(Color.Lerp(
                settings.MinColor,
                settings.MaxColor,
                CurrentHealth / MaxHealth));
        }

        public void SetVelocity(Vector2 velocity)
        {
            if (view == null) return;
            view.SetVelocity(velocity);
        }

        [System.Serializable]
        public struct Settings
        {
            [field: SerializeField]
            public float MaxHealth { get; private set; }

            [field: SerializeField]
            public Color MaxColor { get; private set; }

            [field: SerializeField]
            public Color MinColor { get; private set; }
        }
    }
}

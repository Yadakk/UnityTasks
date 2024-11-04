using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVxTask.Health
{
    public class HealthbarVM : MonoBehaviour
    {
        [SerializeField]
        private Slider healthBar;

        private IHealth ihealth;
        public IHealth IHealth 
        { 
            get => ihealth;
            private set
            {
                UnsubscribeFromIHealth();
                ihealth = value;
                SubscribeToIHealth();
            }
        }

        public void Construct(IHealth ihealth)
        {
            IHealth = ihealth;
        }

        private void HealthChangedHandler()
        {
            UpdateBar();
        }

        private void SubscribeToIHealth()
        {
            if (IHealth == null) return;
            IHealth.OnHealthChanged += HealthChangedHandler;
            UpdateBar();
        }

        private void UnsubscribeFromIHealth()
        {
            if (IHealth == null) return;
            IHealth.OnHealthChanged -= HealthChangedHandler;
        }

        private void UpdateBar()
        {
            healthBar.value = IHealth.CurrentHealth / IHealth.MaxHealth;
        }
    }
}

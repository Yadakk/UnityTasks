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

        private void SubscribeToIHealth()
        {
            if (IHealth == null) return;
            IHealth.OnHealthChanged += HealthChangedHandler;
            IHealth.OnHealthDepleted += HealthDepletedHandler;
        }

        private void UnsubscribeFromIHealth()
        {
            if (IHealth == null) return;
            IHealth.OnHealthChanged -= HealthChangedHandler;
            IHealth.OnHealthDepleted -= HealthDepletedHandler;
        }

        private void HealthChangedHandler()
        {
            healthBar.value = IHealth.CurrentHealth / IHealth.MaxHealth;
        }

        private void HealthDepletedHandler()
        {
            Debug.Log("OnPlayerDeath");
        }
    }
}

using MVxTask.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVxTask.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerView : MonoBehaviour, IDamagable
    {
        private new Rigidbody2D rigidbody;
        private new SpriteRenderer renderer;

        public event Action<float> OnDamaged;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            renderer = GetComponent<SpriteRenderer>();
        }

        public void Damage(float damage)
        {
            OnDamaged?.Invoke(damage);
        }

        public void SetColor(Color color)
        {
            renderer.color = color;
        }

        public void SetVelocity(Vector2 velocity)
        {
            rigidbody.velocity = velocity;
        }
    }
}

using MVxTask.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVxTask
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float damage = 10f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent<IDamagable>(out var damagable)) return;
            damagable.Damage(damage);
        }
    }
}

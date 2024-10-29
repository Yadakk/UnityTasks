using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Prototype))]
    public class Enemy : MonoBehaviour
    {
        private Rigidbody rb;
        private Prototype prototype;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            prototype = GetComponent<Prototype>();

            prototype.OnReturnToPool += OnReturnToPoolHandler;
        }

        private void OnDestroy()
        {
            prototype.OnReturnToPool -= OnReturnToPoolHandler;
        }

        private void OnReturnToPoolHandler()
        {
            transform.SetPositionAndRotation(
                prototype.OriginalPrototype.transform.position, 
                prototype.OriginalPrototype.transform.rotation);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        public void ReturnToPool()
        {
            prototype.ReturnToPool();
        }

        public void Say(string text)
        {
            Debug.Log(text);
        }
    }
}

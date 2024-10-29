using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    [RequireComponent(typeof(Prototype))]
    public class Enemy : MonoBehaviour
    {
        private Prototype prototype;

        private void Awake()
        {
            prototype = GetComponent<Prototype>();

            prototype.OnReturnToPool += OnReturnToPoolHandler;
        }

        private void OnDestroy()
        {
            prototype.OnReturnToPool -= OnReturnToPoolHandler;
        }

        private void OnReturnToPoolHandler()
        {
            transform.position = prototype.OriginalPrototype.transform.position;
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

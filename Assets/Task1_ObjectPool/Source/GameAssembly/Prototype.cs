using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Prototype : MonoBehaviour
    {
        private readonly Queue<Prototype> pool = new();

        public event System.Action OnReturnToPool;

        public Prototype OriginalPrototype { get; private set; }

        private void Start()
        {
            if (OriginalPrototype != null) return;
            gameObject.SetActive(false);
        }

        public T Instantiate<T>() where T : Component
        {
            if (!TryDequeuePool(out var prototype))
            {
                prototype = Instantiate(this, transform.parent);
                prototype.gameObject.SetActive(true);
                prototype.SetOriginalPrototype(this);
            }

            return prototype.GetComponent<T>();
        }

        public void ReturnToPool()
        {
            if (OriginalPrototype == null) throw new System.Exception("Can't return to pool original prototype");
            OriginalPrototype.EnqueuePool(this);
            OnReturnToPool?.Invoke();
        }

        public void SetOriginalPrototype(Prototype prototype)
        {
            OriginalPrototype = prototype;
        }

        private void EnqueuePool(Prototype prototype)
        {
            pool.Enqueue(prototype);
            prototype.gameObject.SetActive(false);
        }

        private bool TryDequeuePool(out Prototype prototype)
        {
            bool wasDequeued = pool.TryDequeue(out prototype);
            if (!wasDequeued) return false;
            prototype.gameObject.SetActive(true);

            return true;
        }
    }
}
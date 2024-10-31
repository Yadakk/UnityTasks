using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner spawner;

        private void Update()
        {
            if (GetKeyDown(KeyCode.Space)) SpaceHandler();
            if (GetKeyDown(KeyCode.Backspace)) BackspaceHandler();
        }

        private void SpaceHandler()
        {
            spawner.Spawn();
        }

        private void BackspaceHandler()
        {
            spawner.Despawn();
        }

        private bool GetKeyDown(KeyCode keyCode)
        {
            return Input.GetKeyDown(keyCode);
        }
    }
}

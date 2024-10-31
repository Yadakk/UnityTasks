using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVxTask.Player
{
    public class PlayerView : MonoBehaviour
    {
        public void ViewPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}

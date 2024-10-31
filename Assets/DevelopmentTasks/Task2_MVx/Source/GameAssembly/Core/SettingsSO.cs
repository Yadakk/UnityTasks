using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVxTask.Player;

namespace MVxTask.Core
{
    public class SettingsSO : ScriptableObject
    {
        [field: SerializeField]
        public PlayerModel.Settings PlayerModel { get; private set; }
    }
}

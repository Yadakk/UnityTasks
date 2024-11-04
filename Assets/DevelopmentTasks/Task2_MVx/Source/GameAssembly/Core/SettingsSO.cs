using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVxTask.Player;

namespace MVxTask.Core
{
    [CreateAssetMenu(fileName = "SettingSO", menuName = "SettingsSO", order = 51)]
    public class SettingsSO : ScriptableObject
    {
        [field: SerializeField]
        public Bootstrap.Settings Bootstrap { get; private set; }

        [field: SerializeField]
        public PlayerModel.Settings PlayerModel { get; private set; }

        [field: SerializeField]
        public PlayerController.Settings PlayerController { get; private set; }
    }
}

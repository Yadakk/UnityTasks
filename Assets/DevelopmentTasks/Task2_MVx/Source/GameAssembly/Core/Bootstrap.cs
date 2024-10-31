using MVxTask.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVxTask.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private SettingsSO settingsSO;

        [SerializeField]
        private PlayerView playerView;

        private PlayerModel playerModel;

        private void Awake()
        {
            playerModel = new(settingsSO.PlayerModel, playerView);
        }
    }
}

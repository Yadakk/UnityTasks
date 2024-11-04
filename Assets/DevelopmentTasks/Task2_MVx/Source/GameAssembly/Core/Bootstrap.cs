using MVxTask.Player;
using MVxTask.Health;
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
        private HealthbarVM healthbarVM;

        private Settings settings;

        private PlayerView playerView;
        private PlayerModel playerModel;
        private PlayerController playerController;
        private PlayerInputBinder playerInputBinder;

        private void Awake()
        {
            settings = settingsSO.Bootstrap;
            SetupPlayer();
            SetupUI();
        }

        private void SetupPlayer()
        {
            playerView = Instantiate(settings.PlayerViewPrefab);
            playerModel = new(settingsSO.PlayerModel, playerView);
            playerController = new(settingsSO.PlayerController, playerModel, playerView);
            playerInputBinder = new(playerController);
            playerInputBinder.SubscribeToAssetAndEnable();
        }

        private void SetupUI()
        {
            healthbarVM.Construct(playerModel);
        }

        private void Update()
        {
            playerController.Tick();
        }

        private void OnDestroy()
        {
            playerInputBinder.UnsubscribeFromAssetAndDisable();
        }

        [System.Serializable]
        public struct Settings
        {
            [field: SerializeField]
            public PlayerView PlayerViewPrefab { get; private set; }
        }
    }
}

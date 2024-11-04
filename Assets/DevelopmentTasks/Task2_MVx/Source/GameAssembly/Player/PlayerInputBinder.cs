using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MVxTask.Player
{
    public class PlayerInputBinder
    {
        public PlayerInputBinder inputBinder;

        private readonly GameInputAsset inputAsset = new();
        private readonly PlayerController controller;

        public PlayerInputBinder(PlayerController controller)
        {
            this.controller = controller;
        }

        public void SubscribeToAssetAndEnable()
        {
            inputAsset.Player.OnMove.performed += OnMoveHandler;
            inputAsset.Player.OnMove.canceled += OnMoveHandler;
            inputAsset.Enable();
        }

        public void UnsubscribeFromAssetAndDisable()
        {
            inputAsset.Player.OnMove.performed -= OnMoveHandler;
            inputAsset.Player.OnMove.canceled -= OnMoveHandler;
            inputAsset.Disable();
        }

        private void OnMoveHandler(InputAction.CallbackContext context)
        {
            Vector2 dir = context.ReadValue<Vector2>();
            controller.SetDirection(dir);
        }
    }
}

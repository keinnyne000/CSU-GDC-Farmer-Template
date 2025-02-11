using System;
using Farmer.GlobalStateManagement;
using UnityEngine;

namespace Farmer.PlayerInput
{
    public class Input : MonoBehaviour
    {
        InputActions inputActions;
        
        private void OnEnable()
        {
            inputActions = new();
            inputActions.Enable();
            
            inputActions.Gameplay.Escape.performed += _ => OnEscapePressed();
            inputActions.Gameplay.Inventory.performed += _ => OnInventoryPressed();
        }
        
        private void OnDisable()
        {
            inputActions.Gameplay.Escape.performed -= _ => OnEscapePressed();
            inputActions.Gameplay.Inventory.performed -= _ => OnInventoryPressed();
            
            inputActions.Disable();
        }

        void OnEscapePressed()
        {
            GlobalState.Instance.SetState(GlobalState.Instance.CurrentState == GameState.Paused ? GameState.InGame : GameState.Paused);
        }

        void OnInventoryPressed()
        {
            GlobalState.Instance.SetState(GlobalState.Instance.CurrentState == GameState.Inventory ? GameState.InGame : GameState.Inventory);
        }
    }
}
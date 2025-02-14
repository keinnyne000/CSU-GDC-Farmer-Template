using System;
using Farmer.GlobalStateManagement;
using Farmer.Player;
using UnityEngine;

namespace Farmer.PlayerInput
{
    public class Input : MonoBehaviour
    {
        InputActions inputActions;
        [SerializeField] PlayerInventory playerInventory;
        
        private void OnEnable()
        {
            inputActions = new();
            inputActions.Enable();
            
            inputActions.Gameplay.Escape.performed += _ => OnEscapePressed();
            inputActions.Gameplay.Inventory.performed += _ => OnInventoryPressed();
            inputActions.Gameplay.Hotbar.performed += _ => OnHotbarPressed();
            inputActions.Gameplay.LMB.performed += _ => OnLMBPressed();
        }
        
        private void OnDisable()
        {
            inputActions.Gameplay.Escape.performed -= _ => OnEscapePressed();
            inputActions.Gameplay.Inventory.performed -= _ => OnInventoryPressed();
            inputActions.Gameplay.Hotbar.performed -= _ => OnHotbarPressed();
            inputActions.Gameplay.LMB.performed -= _ => OnLMBPressed();
            
            inputActions.Disable();
        }

        void OnHotbarPressed()
        { 
            playerInventory.SetHotbarIndex((int)inputActions.Gameplay.Hotbar.ReadValue<float>());
        }
        
        void OnLMBPressed()
        {
            playerInventory.UseHotbarItem();
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
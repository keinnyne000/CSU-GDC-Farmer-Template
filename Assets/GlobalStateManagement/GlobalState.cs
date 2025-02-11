using System;
using UnityEngine;

namespace Farmer.GlobalStateManagement
{
    public class GlobalState : MonoBehaviour
    {
        public static GlobalState Instance { get; private set; }
        public event Action<GameState> OnGameStateChanged;
        public GameState CurrentState { get; private set; }
        
        private void OnEnable()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        public void SetState(GameState state)
        {
            CurrentState = state;
            OnGameStateChanged?.Invoke(state);
        }
    }
    
    public enum GameState
    {
        Launching,
        InGame,
        Paused,
        Inventory
    }
}
using System;
using UnityEngine;

namespace Farmer.GlobalStateManagement
{
    // This class is what's know as a Singleton, it's used to manage the game state.
    // It's a singleton because of the "Instance" property, which is set to "this" in the Awake method.
    // It allows for easy yet controlled access to the game state.
    // Singletons should be used sparingly, but game state management is a good use case for them.
    public class GlobalState : MonoBehaviour
    {
        public static GlobalState Instance { get; private set; }
        public event Action<GameState> OnGameStateChanged;
        public GameState CurrentState { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        private void Start()
        {
            SetState(GameState.InGame);
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
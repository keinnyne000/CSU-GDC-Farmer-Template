using System;
using UnityEngine;

namespace Farmer.GlobalStateManagement
{
    public class TimeManager : MonoBehaviour
    {
        private void Start()
        {
            GlobalState.Instance.OnGameStateChanged += OnGameStateChanged;
        }
        
        private void OnDestroy()
        {
            GlobalState.Instance.OnGameStateChanged -= OnGameStateChanged;
        }
        
        // This method is used to control the time scale of the game based on the game state.
        // It subscribes to the OnGameStateChanged event in the GlobalState class to react to changes.
        void OnGameStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Launching:
                    Time.timeScale = 0;
                    break;
                case GameState.InGame:
                    Time.timeScale = 1;
                    break;
                case GameState.Paused:
                    Time.timeScale = 0;
                    break;
                case GameState.Inventory:
                    Time.timeScale = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}
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
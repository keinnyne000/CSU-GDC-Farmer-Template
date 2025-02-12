using UnityEngine;

namespace Farmer.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] GameObject inventoryUI;
        [SerializeField] GameObject pauseUI;
        [SerializeField] GameObject launchUI;
        [SerializeField] GameObject gameUI;

        void Start()
        {
            GlobalStateManagement.GlobalState.Instance.OnGameStateChanged += OnGameStateChanged;
        }

        void OnGameStateChanged(GlobalStateManagement.GameState state)
        {
            inventoryUI.SetActive(state == GlobalStateManagement.GameState.Inventory);
            pauseUI.SetActive(state == GlobalStateManagement.GameState.Paused);
            launchUI.SetActive(state == GlobalStateManagement.GameState.Launching);
            gameUI.SetActive(state == GlobalStateManagement.GameState.InGame);
        }
        
        void OnDestroy()
        {
            GlobalStateManagement.GlobalState.Instance.OnGameStateChanged -= OnGameStateChanged;
        }
    }
}
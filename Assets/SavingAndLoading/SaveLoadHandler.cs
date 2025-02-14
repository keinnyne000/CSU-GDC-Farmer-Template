using UnityEngine;

namespace Farmer.SavingAndLoading
{
    // This is a simple class that uses the IOHandler class to save and load the world!
    public static class SaveLoadHandler
    {
        const string FILE_SAVE_NAME = "savefile";
        
        public static bool HasSaveFile()
        {
            return IOHandler.FileExists(Application.persistentDataPath + "/" + FILE_SAVE_NAME);
        }
        
        public static void SaveGame(Vector2 playerPosition, (uint, int)[] playerInventory)
        {
            WorldSaveData saveData = new WorldSaveData(playerPosition, playerInventory);
            IOHandler.WriteJSON(Application.persistentDataPath + "/" + FILE_SAVE_NAME, saveData);
        }
        
        public static WorldSaveData LoadGame()
        {
            return IOHandler.ReadJSON<WorldSaveData>(Application.persistentDataPath + "/" + FILE_SAVE_NAME);
        }
    }
}
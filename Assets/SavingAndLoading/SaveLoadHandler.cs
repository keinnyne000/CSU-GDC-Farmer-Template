using UnityEngine;

namespace Farmer.SavingAndLoading
{
    // This is a simple class that uses the IOHandler class to save and load the world!
    public static class SaveLoadHandler
    {
        const string FILE_SAVE_NAME = "save";
        
        public static bool HasSaveFile()
        {
            if(IOHandler.FileExists(Application.persistentDataPath + "/" + FILE_SAVE_NAME) == false) return false;
            return IOHandler.FileIs<WorldSaveData>(Application.persistentDataPath + "/" + FILE_SAVE_NAME);
        }
        
        public static void DeleteSaveFile()
        {
            IOHandler.DeleteFile(Application.persistentDataPath + "/" + FILE_SAVE_NAME);
        }
        
        public static void SaveGame(Vector2 playerPosition, uint[] playerInventoryIds, int[] playerInventoryQuantities)
        {
            WorldSaveData saveData = new WorldSaveData(playerPosition, playerInventoryIds, playerInventoryQuantities);
            IOHandler.WriteJSON(Application.persistentDataPath + "/" + FILE_SAVE_NAME, saveData);
        }
        
        public static WorldSaveData LoadGame()
        {
            return IOHandler.ReadJSON<WorldSaveData>(Application.persistentDataPath + "/" + FILE_SAVE_NAME);
        }
    }
}
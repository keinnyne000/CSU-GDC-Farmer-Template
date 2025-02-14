using UnityEngine;

namespace Farmer.SavingAndLoading
{
    // This is a simple class that handles saving and loading data to and from JSON files.
    // The "<T>" represents a generic type, which means that this class can handle any type of data!
    public static class IOHandler
    {
        public static void WriteJSON<T>(string path, T data)
        {
            string json = JsonUtility.ToJson(data);
            System.IO.File.WriteAllText(path, json);
        }

        public static T ReadJSON<T>(string path)
        {
            if(!FileExists(path)) return default;
            string json = System.IO.File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }

        public static bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public static bool FileIs<T>(string path)
        {
            return System.IO.File.Exists(path) && JsonUtility.FromJson<T>(System.IO.File.ReadAllText(path)) != null;
        }
    }
}
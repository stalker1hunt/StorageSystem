using UnityEngine;

namespace StorageSystem
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Debug.Log("[Storage System] " + message);
        }

        public static void LogError(string message)
        {
            Debug.LogError("[Storage System] " + message);
        }
    }
}
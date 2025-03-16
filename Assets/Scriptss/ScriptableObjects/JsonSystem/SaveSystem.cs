using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/playerdata.json";

    public static void SavePlayerData(PlayerDetailsSO playerDetails)
    {
        string json = JsonUtility.ToJson(playerDetails);
        File.WriteAllText(savePath, json);
        Debug.Log("Data Saved: " + json);
    }

    public static Vector3 LoadPlayerData(PlayerDetailsSO playerDetails)
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, playerDetails);
            Debug.Log("Data Loaded: " + json);
            return playerDetails.checkpointPosition; // Return checkpoint position

        }
        else
        {
            Debug.LogWarning("Save file not found. Creating new data.");
            return Vector3.zero; // Default position if no save file is found

        }
    }
}

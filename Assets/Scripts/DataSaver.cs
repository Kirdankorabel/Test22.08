using System;
using System.IO;
using System.Text;
using UnityEngine;

public class DataSaver
{
    public static void saveData<T>(T dataToSave, string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        string jsonData = JsonUtility.ToJson(dataToSave, true);
        byte[] jsonByte = Encoding.ASCII.GetBytes(jsonData);

        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        try
        {
            File.WriteAllBytes(tempPath, jsonByte);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To PlayerInfo Data to: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }

    public static T loadData<T>(string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
            return default(T);

        if (!File.Exists(tempPath))
            return default(T);

        byte[] jsonByte = null;
        try
        {
            jsonByte = File.ReadAllBytes(tempPath);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Load Data from: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }

        string jsonData = Encoding.ASCII.GetString(jsonByte);

        object resultValue = JsonUtility.FromJson<T>(jsonData);
        return (T)Convert.ChangeType(resultValue, typeof(T));
    }
}
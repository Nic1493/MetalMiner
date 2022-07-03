using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Extension class to manage loading and saving user data.
/// </summary>
public static class FileHandler
{
    static readonly string dataDirectoryPath = Path.Combine(Application.persistentDataPath, "Data");
    static readonly string dataFilePath = Path.Combine(dataDirectoryPath, "userdata.json");

    public static bool TryLoad(ref UserData userData)
    {
        Directory.CreateDirectory(dataDirectoryPath);

        if (File.Exists(dataFilePath))
        {
            try
            {
                using FileStream fs = new FileStream(dataFilePath, FileMode.Open);
                using StreamReader sr = new StreamReader(fs);
                string data = sr.ReadToEnd();

                JsonUtility.FromJsonOverwrite(data, userData);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error occurred when trying to load data from file \n{e}");
                return false;
            }
        }

        return false;
    }

    public static void Save(this UserData userData)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dataFilePath));

            var json = JsonUtility.ToJson(userData, true);

            using FileStream fs = new FileStream(dataFilePath, FileMode.Create);
            using StreamWriter sw = new StreamWriter(fs);
            sw.Write(json);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error occurred when trying to save data to file \n{e}");
        }
    }
}

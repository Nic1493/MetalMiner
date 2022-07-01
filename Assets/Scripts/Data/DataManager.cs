using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] UserData userData;
    [SerializeField] IntObject[] currencyObjects;

    void LoadData()
    {
        userData.Load();

        for (int i = 0; i < currencyObjects.Length; i++)
        {
            currencyObjects[i].value = userData.currencies[i];
        }
    }

    void SaveData()
    {
        for (int i = 0; i < currencyObjects.Length; i++)
        {
            userData.currencies[i] = currencyObjects[i].value;
        }

        userData.Save();
    }

    void Start()
    {
        LoadData();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }
}
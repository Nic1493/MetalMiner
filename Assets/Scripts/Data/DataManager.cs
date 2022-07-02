using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] UserData userData;
    [SerializeField] CurrencyObject[] currencyObjects;

    void LoadData()
    {
        userData.Load();

        // make sure dictionary is initialized
        if (userData.currencies.Count == 0)
        {
            for (int i = 0; i < currencyObjects.Length; i++)
            {
                userData.currencies.Add(currencyObjects[i].currencyType, 0);
            }
        }

        for (int i = 0; i < currencyObjects.Length; i++)
        {
            CurrencyType type = currencyObjects[i].currencyType;
            currencyObjects[i].amount = userData.currencies[type];
        }
    }

    void SaveData()
    {
        for (int i = 0; i < userData.currencies.Count; i++)
        {
            CurrencyType type = currencyObjects[i].currencyType;
            userData.currencies[type] = currencyObjects[i].amount;
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
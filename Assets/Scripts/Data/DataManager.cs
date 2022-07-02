using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] UserData userData;

    [SerializeField] CurrencyObject[] currencyObjects;
    [SerializeField] BuildingObject[] buildingObjects;

    void LoadData()
    {
        userData.Load();

        // make sure currency dictionary is initialized
        if (userData.currencies.Count == 0)
        {
            for (int i = 0; i < currencyObjects.Length; i++)
            {
                userData.currencies.Add(currencyObjects[i].currencyType, 0);
            }
        }

        // load currency data from UserData to currency scriptable objects
        for (int i = 0; i < currencyObjects.Length; i++)
        {
            CurrencyType type = currencyObjects[i].currencyType;
            currencyObjects[i].amount = userData.currencies[type];
        }

        // make sure building dictionary is initialized
        if (userData.buildings.Count == 0)
        {
            for (int i = 0; i < buildingObjects.Length; i++)
            {
                userData.buildings.Add(buildingObjects[i].buildingType, buildingObjects[i].count);
            }
        }

        // load building data from UserData to building scriptable objects
        for (int i = 0; i < buildingObjects.Length; i++)
        {
            BuildingType type = buildingObjects[i].buildingType;
            buildingObjects[i].count = userData.buildings[type];
        }
    }

    void SaveData()
    {
        // save currency data from currency scriptable objects to UserData
        for (int i = 0; i < userData.currencies.Count; i++)
        {
            CurrencyType type = currencyObjects[i].currencyType;
            userData.currencies[type] = currencyObjects[i].amount;
        }

        // save building data from building scriptable objects to UserData
        for (int i = 0; i < userData.buildings.Count; i++)
        {
            BuildingType type = buildingObjects[i].buildingType;
            userData.buildings[type] = buildingObjects[i].count;
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
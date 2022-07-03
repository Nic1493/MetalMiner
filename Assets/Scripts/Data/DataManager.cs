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
        if (userData.currencyAmounts.Count == 0)
        {
            for (int i = 0; i < currencyObjects.Length; i++)
            {
                userData.currencyAmounts.Add(currencyObjects[i].currencyType, 0);
            }
        }

        // load currency data from UserData to currency scriptable objects
        for (int i = 0; i < currencyObjects.Length; i++)
        {
            CurrencyType type = currencyObjects[i].currencyType;
            currencyObjects[i].amount = userData.currencyAmounts[type];
        }

        // make sure building dictionary is initialized
        if (userData.buildingCounts.Count == 0)
        {
            for (int i = 0; i < buildingObjects.Length; i++)
            {
                userData.buildingCounts.Add(buildingObjects[i].buildingType, buildingObjects[i].count);
            }
        }

        // load building data from UserData to building scriptable objects
        for (int i = 0; i < buildingObjects.Length; i++)
        {
            BuildingType type = buildingObjects[i].buildingType;
            buildingObjects[i].count = userData.buildingCounts[type];
        }
    }

    void SaveData()
    {
        // save currency data from currency scriptable objects to UserData
        for (int i = 0; i < userData.currencyAmounts.Count; i++)
        {
            CurrencyType type = currencyObjects[i].currencyType;
            userData.currencyAmounts[type] = currencyObjects[i].amount;
        }

        // save building data from building scriptable objects to UserData
        for (int i = 0; i < userData.buildingCounts.Count; i++)
        {
            BuildingType type = buildingObjects[i].buildingType;
            userData.buildingCounts[type] = buildingObjects[i].count;
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
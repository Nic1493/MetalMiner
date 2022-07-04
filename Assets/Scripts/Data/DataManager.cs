using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] UserData userData;

    [SerializeField] CurrencyObject[] currencyObjects;
    [SerializeField] BuildingObject[] buildingObjects;

    void LoadData()
    {
        if (!FileHandler.TryLoad(ref userData))
        {
            for (int i = 0; i < currencyObjects.Length; i++)
            {
                userData.currencyAmounts.Add(currencyObjects[i].currencyType, 0);
            }

            for (int i = 0; i < buildingObjects.Length; i++)
            {
                userData.buildings.Add(buildingObjects[i].building);
            }

            userData.buildingTypesUnlocked = 0;
        }

        // load currency data from UserData to currency scriptable objects
        for (int i = 0; i < currencyObjects.Length; i++)
        {
            CurrencyType type = currencyObjects[i].currencyType;
            currencyObjects[i].amount = userData.currencyAmounts[type];
        }

        // load building data from UserData to building scriptable objects
        for (int i = 0; i < buildingObjects.Length; i++)
        {
            buildingObjects[i].building.count = userData.buildings[i].count;
            buildingObjects[i].building.level = userData.buildings[i].level;
            buildingObjects[i].building.purchaseCost = userData.buildings[i].purchaseCost;
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
        for (int i = 0; i < userData.buildings.Count; i++)
        {
            userData.buildings[i] = buildingObjects[i].building;
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

        #region DEBUG
#if UNITY_EDITOR
        userData.currencyAmounts.Clear();
        userData.buildings.Clear();
        userData.buildingTypesUnlocked = 0;

        for (int i = 0; i < currencyObjects.Length; i++)
        {
            currencyObjects[i].amount = 0;
        }

        for (int i = 0; i < buildingObjects.Length; i++)
        {
            buildingObjects[i].building.count = 0;
            buildingObjects[i].building.level = 1;
            buildingObjects[i].building.initialPurchaseCost = 10;
        }
#endif
        #endregion
    }
}
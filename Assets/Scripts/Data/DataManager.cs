using System;
using System.Collections.Generic;
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

            userData.buildings = new List<Building>(Enum.GetNames(typeof(BuildingType)).Length);

            for (int i = 0; i < buildingObjects.Length; i++)
            {
                userData.buildings.Add(new Building());
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
            Building building = buildingObjects[i].building;

            building.count = userData.buildings[i].count;
            building.level = userData.buildings[i].level;
            building.speedMultiplier = userData.buildings[i].speedMultiplier;
            building.purchaseCost = userData.buildings[i].purchaseCost;
            building.upgradeCosts = userData.buildings[i].upgradeCosts;
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
            buildingObjects[i].building.initialPurchaseCost = 100;
        }
#endif
        #endregion
    }
}
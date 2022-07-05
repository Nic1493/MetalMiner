using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Scriptable Object/Game Type/Building")]
public class BuildingObject : ScriptableObject
{
    public Building building;
}

[Serializable]
public class Building
{
    public BuildingType buildingType;
    public int count;
    public int level;
    public float speedMultiplier;

    [Space]

    public CurrencyType purchaseCurrencyType;
    public float purchaseCost;
    public float initialPurchaseCost;

    [Space]

    public CurrencyType upgradeCurrencyType;
    public SerializableDictionary<UpgradeType, float> upgradeCosts;
    public SerializableDictionary<UpgradeType, float> initialUpgradeCosts;

    public Building()
    {
        buildingType = BuildingType.CopperMine;
        count = 0;
        level = 1;
        speedMultiplier = 1f;

        purchaseCurrencyType = CurrencyType.Copper;
        initialPurchaseCost = 100f;
        purchaseCost = initialPurchaseCost;

        upgradeCurrencyType = CurrencyType.Copper;

        upgradeCosts = new SerializableDictionary<UpgradeType, float>
        {
            { UpgradeType.LevelUp, 1000f },
            { UpgradeType.SpeedUp, 500f }
        };

        initialUpgradeCosts = new SerializableDictionary<UpgradeType, float>
        {
            { UpgradeType.LevelUp, 1000f },
            { UpgradeType.SpeedUp, 500f }
        };
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgradeShop : BuildingShop
{
    public event Action<BuildingObject> LevelUpAction;
    public event Action<BuildingObject> SpeedUpAction;

    // called upon pressing building upgrade buttons
    public void UpgradeBuildingLevel(BuildingObject buildingObject)
    {
        UpgradeType upgradeType = UpgradeType.LevelUp;
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.upgradeCurrencyType];
        float purchaseCost = buildingObject.building.upgradeCosts[upgradeType];

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;

            buildingObject.building.level++;
            UpdateUpgradeCost(buildingObject, upgradeType);

            LevelUpAction?.Invoke(buildingObject);
        }
    }

    public void UpgradeBuildingSpeed(BuildingObject buildingObject)
    {
        UpgradeType upgradeType = UpgradeType.SpeedUp;
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.upgradeCurrencyType];
        float purchaseCost = buildingObject.building.upgradeCosts[upgradeType];

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;

            buildingObject.building.speedMultiplier += 0.1f;
            UpdateUpgradeCost(buildingObject, upgradeType);

            SpeedUpAction?.Invoke(buildingObject);
        }
    }

    // calculate new upgrade cost
    void UpdateUpgradeCost(BuildingObject buildingObject, UpgradeType upgradeType)
    {
        Building building = buildingObject.building;

        switch (upgradeType)
        {
            case UpgradeType.LevelUp:
                building.upgradeCosts[upgradeType] = building.initialUpgradeCosts[upgradeType] * Mathf.Pow(1.2f, building.level - 1);
                break;

            case UpgradeType.SpeedUp:
                building.upgradeCosts[upgradeType] = building.initialUpgradeCosts[upgradeType] * Mathf.Pow(3.6f, building.speedMultiplier - (1f - 0.1f));
                break;

            default:
                break;
        }
    }
}
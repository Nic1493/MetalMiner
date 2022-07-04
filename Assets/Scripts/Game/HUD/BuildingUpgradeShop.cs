using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgradeShop : BuildingShop
{
    public event Action LevelUpAction;
    public event Action SpeedUpAction;

    // called upon pressing building upgrade buttons
    public void UpgradeBuildingLevel(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.buildingType];
        float purchaseCost = buildingObject.building.upgradeCosts[UpgradeType.LevelUp];

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;

            buildingObject.building.level++;
            LevelUpAction?.Invoke();

            UpdateUpgradeCost(buildingObject, UpgradeType.LevelUp);
        }
    }

    public void UpgradeBuildingSpeed(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.buildingType];
        float purchaseCost = buildingObject.building.upgradeCosts[UpgradeType.SpeedUp];

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;

            buildingObject.building.speedMultiplier += 0.1f;
            SpeedUpAction?.Invoke();

            UpdateUpgradeCost(buildingObject, UpgradeType.SpeedUp);
        }
    }

    // calculate new upgrade cost
    // to-do: develop formula
    void UpdateUpgradeCost(BuildingObject buildingObject, UpgradeType upgradeType)
    {
        // to-do: impl.
    }
}
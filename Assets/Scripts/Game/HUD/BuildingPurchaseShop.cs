using System;
using UnityEngine;

public class BuildingPurchaseShop : BuildingShop
{
    public event Action<BuildingObject> PurchaseAction;

    // enable building buttons based on amount of building types unlocked
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i <= userData.buildingTypesUnlocked;
        }
    }

    // called upon pressing building purchase buttons
    public void PurchaseBuilding(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.purchaseCurrencyType];
        float purchaseCost = buildingObject.building.purchaseCost;

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;
            buildingObject.building.count++;

            PurchaseAction?.Invoke(buildingObject);

            if (buildingObject.building.count == 1)
            {
                BuildingType buildingType = buildingObject.building.buildingType;

                // display next building button
                if ((int)buildingType + 1 < buttons.Length)
                {
                    buttons[(int)buildingType + 1].interactable = true;
                }

                userData.buildingTypesUnlocked++;
            }

            UpdatePurchaseCost(buildingObject);
        }
    }

    // calculate new building cost
    // y = 1.2 ^ (x - 1), where x = amount of buildings owned
    void UpdatePurchaseCost(BuildingObject buildingObject)
    {
        float newPurchaseCost = buildingObject.building.initialPurchaseCost * Mathf.Pow(1.2f, buildingObject.building.count);
        buildingObject.building.purchaseCost = newPurchaseCost;
    }
}
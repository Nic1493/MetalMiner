using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingShop : MonoBehaviour
{
    [SerializeField] UserData userData;

    [Space]

    [SerializeField] BuildingObject[] buildingObjects;
    [SerializeField] CurrencyObject[] currencyObjects;

    Button[] buildingButtons;

    public event Action PurchaseAction;
    public event Action LevelUpAction;
    public event Action SpeedUpAction;

    void Awake()
    {
        buildingButtons = GetComponentsInChildren<Button>();
    }

    // enable building buttons based on amount of building types unlocked
    void Start()
    {
        for (int i = 0; i < buildingButtons.Length; i++)
        {
            buildingButtons[i].interactable = i <= userData.buildingTypesUnlocked;
        }
    }

    // called upon pressing building purchase buttons
    public void PurchaseBuilding(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.costCurrencyType];
        float purchaseCost = buildingObject.building.purchaseCost;

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;
            buildingObject.building.count++;

            PurchaseAction?.Invoke();

            if (buildingObject.building.count == 1)
            {
                BuildingType buildingType = buildingObject.building.buildingType;

                // display next building button
                if ((int)buildingType + 1 < buildingButtons.Length)
                {
                    buildingButtons[(int)buildingType + 1].interactable = true;
                }

                userData.buildingTypesUnlocked++;
            }

            UpdatePurchaseCost(buildingObject);
        }
    }

    // called upon pressing building upgrade buttons
    public void UpgradeBuildingLevel(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.buildingType];
        float purchaseCost = buildingObject.building.upgradeCosts[UpgradeType.LevelUp];
        print(purchaseCost);

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
        print(purchaseCost);

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;

            buildingObject.building.speedMultiplier += 0.1f;
            SpeedUpAction?.Invoke();

            UpdateUpgradeCost(buildingObject, UpgradeType.SpeedUp);
        }
    }

    // calculate new building cost
    // y = 1.2 ^ (x - 1), where x = amount of buildings owned
    void UpdatePurchaseCost(BuildingObject buildingObject)
    {
        float newPurchaseCost = buildingObject.building.initialPurchaseCost * Mathf.Pow(1.2f, buildingObject.building.count);
        buildingObject.building.purchaseCost = newPurchaseCost;
    }

    // calculate new upgrade cost
    // to-do: develop formula
    void UpdateUpgradeCost(BuildingObject buildingObject, UpgradeType upgradeType)
    {
        // to-do: impl.
    }
}
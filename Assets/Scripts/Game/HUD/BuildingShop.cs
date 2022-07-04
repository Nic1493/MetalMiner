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

    public event Action<BuildingType> PurchaseAction;
    public event Action<BuildingType> FirstPurchaseAction;

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

    // called upon pressing building buttons
    public void PurchaseBuilding(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.building.costCurrencyType];
        float purchaseCost = buildingObject.building.purchaseCost;

        if (currency.amount >= purchaseCost)
        {
            currency.amount -= purchaseCost;

            BuildingType buildingType = buildingObject.building.buildingType;
            PurchaseAction?.Invoke(buildingType);

            if (buildingObject.building.count == 1)
            {
                FirstPurchaseAction?.Invoke(buildingObject.building.buildingType);

                // display next building button
                if ((int)buildingType + 1 < buildingButtons.Length)
                {
                    buildingButtons[(int)buildingType + 1].interactable = true;
                }

                userData.buildingTypesUnlocked++;
            }
        }
    }
}
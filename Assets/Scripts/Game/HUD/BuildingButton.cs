using UnityEngine;
using TMPro;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] BuildingObject buildingObject;

    [Space]

    [SerializeField] TextMeshProUGUI buildingCostText;
    [SerializeField] TextMeshProUGUI buildingCountText;

    void Awake()
    {
        GetComponentInParent<BuildingShop>().PurchaseAction += OnPurchase;
    }

    void OnPurchase(BuildingType buildingType)
    {
        if (buildingObject.building.buildingType == buildingType)
        {
            buildingObject.building.count++;
            UpdateBuildingCost();
            UpdateTexts();
        }
    }

    void Start()
    {
        UpdateBuildingCost();
        UpdateTexts();
    }

    // calculate new building cost
    // y = 1.2 ^ (x - 1), where x = amount of buildings owned
    void UpdateBuildingCost()
    {
        float newPurchaseCost = buildingObject.building.initialPurchaseCost * Mathf.Pow(1.2f, buildingObject.building.count);
        buildingObject.building.purchaseCost = newPurchaseCost;
    }

    void UpdateTexts()
    {
        buildingCostText.text = ((int)buildingObject.building.purchaseCost).ToString();
        buildingCountText.text = $"{buildingObject.building.count}x";
    }
}
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
        if (buildingObject.buildingType == buildingType)
        {
            buildingObject.count++;
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
        int newPurchaseCost = Mathf.Min(Mathf.RoundToInt(buildingObject.initialPurchaseCost * Mathf.Pow(1.2f, buildingObject.count)), int.MaxValue);
        buildingObject.purchaseCost = newPurchaseCost;
    }

    void UpdateTexts()
    {
        buildingCostText.text = buildingObject.purchaseCost.ToString();
        buildingCountText.text = $"{buildingObject.count}x";
    }
}
using UnityEngine;
using TMPro;

public class BuildingShop : MonoBehaviour
{
    [SerializeField] BuildingObject[] buildingObjects;
    [SerializeField] CurrencyObject[] currencyObjects;
    [SerializeField] TextMeshProUGUI[] costTexts;

    void Start()
    {
        for (int i = 0; i < costTexts.Length; i++)
        {
            costTexts[i].text = buildingObjects[i].purchaseCost.ToString();
        }
    }

    // called by building purchase buttons
    public void PurchaseBuilding(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.costCurrencyType];
        int buildingCost = buildingObject.purchaseCost;

        if (currency.amount >= buildingCost)
        {
            buildingObject.count++;
            currency.amount -= buildingCost;

            int newPurchaseCost = CalculateBuildingCost(buildingObject);

            buildingObject.purchaseCost = newPurchaseCost;
            costTexts[(int)buildingObject.buildingType].text = newPurchaseCost.ToString();
        }
    }

    // calculate new building cost
    // y = 1.2 ^ (x - 1), where x = amount of buildings owned
    int CalculateBuildingCost(BuildingObject buildingObject)
    {
        int newPurchaseCost = Mathf.Min(Mathf.RoundToInt(buildingObject.initialPurchaseCost * Mathf.Pow(1.2f, buildingObject.count)), int.MaxValue);
        return newPurchaseCost;
    }
}
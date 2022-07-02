using UnityEngine;

public class BuildingShop : MonoBehaviour
{
    [SerializeField] CurrencyObject[] currencyObjects;

    // called by building purchase buttons
    public void PurchaseBuilding(BuildingObject buildingObject)
    {
        CurrencyObject currency = currencyObjects[(int)buildingObject.costCurrencyType];
        int buildingCost = buildingObject.costAmount;

        if (currency.amount >= buildingCost)
        {
            buildingObject.count++;
            currency.amount -= buildingCost;
        }
    }
}
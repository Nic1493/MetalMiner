using UnityEngine;

public class AutoMiner : MonoBehaviour
{
    [SerializeField] BuildingObject buildingObject;
    [SerializeField] CurrencyObject currencyObject;

    void Update()
    {
        float currencyPerSecond = buildingObject.count;
        currencyObject.amount += currencyPerSecond * Time.deltaTime;
    }
}
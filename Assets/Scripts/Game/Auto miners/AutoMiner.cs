using UnityEngine;

public class AutoMiner : MonoBehaviour
{
    [SerializeField] BuildingObject buildingObject;
    [SerializeField] CurrencyObject currencyObject;

    Building building;

    void Start()
    {
        building = buildingObject.building;
    }

    void Update()
    {
        float currencyPerSecond = building.count * building.level * building.speedMultiplier;
        currencyObject.amount += currencyPerSecond * Time.deltaTime;
    }
}
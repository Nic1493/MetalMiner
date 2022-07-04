using UnityEngine;

public class AutoMiner : MonoBehaviour
{
    public CurrencyObject currencyObject;

    [SerializeField] BuildingObject buildingObject;
    Building building;

    float currencyPerSecond;
    public float CurrencyPerSecond
    {
        get => currencyPerSecond;
        private set => currencyPerSecond = value;
    }

    void Start()
    {
        building = buildingObject.building;
    }

    void Update()
    {
        CurrencyPerSecond = building.count * building.level * building.speedMultiplier;
        currencyObject.amount += CurrencyPerSecond * Time.deltaTime;
    }
}
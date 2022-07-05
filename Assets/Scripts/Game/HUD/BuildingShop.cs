using UnityEngine;
using UnityEngine.UI;

public abstract class BuildingShop : MonoBehaviour
{
    [SerializeField] protected UserData userData;

    [Space]

    [SerializeField] protected BuildingObject[] buildingObjects;
    [SerializeField] protected CurrencyObject[] currencyObjects;

    protected Button[] buttons;

    protected virtual void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }
}
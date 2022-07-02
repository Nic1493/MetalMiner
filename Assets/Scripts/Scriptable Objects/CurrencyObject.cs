using UnityEngine;

[CreateAssetMenu(fileName = "New Currency", menuName = "Scriptable Object/Currency")]
public class CurrencyObject : ScriptableObject
{
    public CurrencyType currencyType;
    public int amount;
}

public enum CurrencyType
{
    Copper,
    Silver,
    Gold,
    Platinum,
    Diamond
}
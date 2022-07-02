using UnityEngine;

[CreateAssetMenu(fileName = "New Currency", menuName = "Scriptable Object/Game Type/Currency")]
public class CurrencyObject : ScriptableObject
{
    public CurrencyType currencyType;
    public int amount;
}
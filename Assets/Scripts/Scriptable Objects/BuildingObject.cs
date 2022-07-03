using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Scriptable Object/Game Type/Building")]
public class BuildingObject : ScriptableObject
{
    public BuildingType buildingType;
    public int count;

    [Space]

    public CurrencyType costCurrencyType;
    public float purchaseCost;
    public float initialPurchaseCost;
}
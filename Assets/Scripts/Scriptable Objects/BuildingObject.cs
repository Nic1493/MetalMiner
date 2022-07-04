using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Scriptable Object/Game Type/Building")]
public class BuildingObject : ScriptableObject
{
    public Building building;
}

[Serializable]
public class Building
{
    public BuildingType buildingType;
    public int count;
    public int level;

    [Space]

    public CurrencyType costCurrencyType;
    public float purchaseCost;
    public float initialPurchaseCost;
}
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New User Data", menuName = "Scriptable Object/User Data")]
public class UserData : ScriptableObject
{
    public SerializableDictionary<CurrencyType, int> currencies;
    public SerializableDictionary<BuildingType, int> buildings;

    public int buildingTypesUnlocked;
}
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New User Data", menuName = "Scriptable Object/User Data")]
public class UserData : ScriptableObject
{
    public SerializableDictionary<CurrencyType, float> currencyAmounts;

    public List<Building> buildings;
    public int buildingTypesUnlocked;
}
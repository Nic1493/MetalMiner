using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New User Data", menuName = "Scriptable Object/User Data")]
public class UserData : ScriptableObject
{
    public Dictionary<CurrencyType, int> currencies = new Dictionary<CurrencyType, int>(Enum.GetValues(typeof(CurrencyType)).Length);
}
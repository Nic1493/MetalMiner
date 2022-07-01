using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New User Data", menuName = "Scriptable Object/User Data")]
public class UserData : ScriptableObject
{
    enum CurrencyType
    {
        Copper,
        Silver,
        Gold,
        Platinum,
        Diamond
    }

    public int[] currencies = new int[Enum.GetValues(typeof(CurrencyType)).Length];
}
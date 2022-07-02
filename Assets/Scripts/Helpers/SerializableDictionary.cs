using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] List<TKey> keys = new List<TKey>();
    [SerializeField] List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        // save dictionary to lists
        foreach (var item in this)
        {
            keys.Add(item.Key);
            values.Add(item.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        Clear();

        // load dictionary from lists
        if (keys.Count == values.Count)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                Add(keys[i], values[i]);
            }
        }
    }
}
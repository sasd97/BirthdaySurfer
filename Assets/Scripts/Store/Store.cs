using UnityEngine;
using System.Collections;

public interface Store<K>
{
    void PutBoolean(K key, bool val);
    void PutInteger(K key, int val);
    void PutFloat(K key, float val);
    void PutString(K key, string val);

    bool GetBoolean(K key, bool defaultValue = false);
    int GetInteger(K key, int defaultValue = 0);
    float GetFloat(K key, float defaultValue = 0.0f);
    string GetString(K key, string defaultValue = "");

    void Remove(K key);
    void Clear();
}
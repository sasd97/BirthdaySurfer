using UnityEngine;
using System.Collections;

public interface Store<K>
{
    Store<K> Put<T>(K key, T obj);

    bool GetBoolean(K key, bool defaultValue = false);
    int GetInteger(K key, int defaultValue = 0);
    float GetFloat(K key, float defaultValue = 0.0f);
    long GetLong(K key, long defaultValue = 0L);
    string GetString(K key, string defaultValue = "");

    void Remove(K key);
    void Clear();
}
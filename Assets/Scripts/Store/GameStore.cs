using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameStore: Store<string>
{
    private static GameStore _instance;
    private Dictionary<string, int> _store;
    private Store<string> _prefsStore;

    public GameStore(Store<string> prefsStore) 
    {
        _store = new Dictionary<string, int>();
        _prefsStore = prefsStore;
        OnInit();
    }

    public void OnInit() {
        _store.Add("score", 0);
        _store.Add("record", _prefsStore.GetInteger("record"));
    }

    public Store<string> Put<T>(string key, T obj)
    {
		if (obj is int) {
            if (_store.ContainsKey(key)) _store[key] = Convert.ToInt32(obj);
            else _store.Add(key, Convert.ToInt32(obj));
		} 

        Debug.Log("Putted key: " + key + " value: " + obj);
		return this;
    }

    public bool GetBoolean(string key, bool defaultValue)
    {
        return defaultValue;
    }

    public int GetInteger(string key, int defaultValue)
    {
        if (!_store.ContainsKey(key)) return defaultValue;
        return _store[key];
    }

    public float GetFloat(string key, float defaultValue)
    {
        return defaultValue;
    }

    public long GetLong(string key, long defaultValue)
    {
        return defaultValue;
    }

    public string GetString(string key, string defaultValue)
    {
        return defaultValue;
    }

    public void Remove(string key)
    {
        _store.Remove(key);
    }

    public void Clear()
    {
        _store.Clear();
        OnInit();
    }
}

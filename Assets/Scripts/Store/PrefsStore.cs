using UnityEngine;
using System.Collections;
using System;

public class PrefsStore : Store<string>
{
    public bool GetBoolean(string key, bool defaultValue = false)
    {
        if (!PlayerPrefs.HasKey(key)) return defaultValue;
        int temp = PlayerPrefs.GetInt(key);
        return temp == 0 ? false : true;
    }

    public float GetFloat(string key, float defaultValue = 0)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    public int GetInteger(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public long GetLong(string key, long defaultValue = 0)
    {
        return defaultValue;
    }

    public string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public Store<string> Put<T>(string key, T obj)
    {
        if (obj is bool) 
        {
            PlayerPrefs.SetInt(key, Convert.ToBoolean(obj) ? 1 : 0);
		}
		else if (obj is int)
		{
            PlayerPrefs.SetInt(key, Convert.ToInt32(obj));
		} 
        else if (obj is float)
        {
            PlayerPrefs.SetFloat(key, Convert.ToSingle(obj));
        }
        else if (obj is string)
		{
            PlayerPrefs.SetString(key, Convert.ToString(obj));
		}

        Debug.Log("Putted key: " + key + " value: " + obj);
        PlayerPrefs.Save();
        return this;
    }

    public void Remove(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

	public void Clear()
	{
        PlayerPrefs.DeleteAll();
	}
}

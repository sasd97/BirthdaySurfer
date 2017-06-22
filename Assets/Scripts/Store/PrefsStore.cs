using UnityEngine;
using System.Collections;
using System;

public class PrefsStore : Store<string>
{
	public void PutBoolean(string key, bool val)
	{
		PlayerPrefs.SetInt(key, val ? 1 : 0);
	}

	public void PutInteger(string key, int val)
	{
		PlayerPrefs.SetInt(key, val);
	}

	public void PutFloat(string key, float val)
	{
        PlayerPrefs.SetFloat(key, val);
	}

	public void PutString(string key, string val)
	{
        PlayerPrefs.SetString(key, val);
	}

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

    public string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
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

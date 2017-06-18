using UnityEngine;
using System.Collections;

public class GameManager
{
    private static GameManager _instance;

    private int _score = 0;
    private int _record = PlayerPrefs.GetInt(PrefsConfigs.RecordPrefs, 0);

    private GameManager() 
    {
    }

    public static GameManager GetInstance()
    {
        if (_instance == null) _instance = new GameManager();
        return _instance;
    }

    public void IncreaseScore() 
    {
        _score++;
        if (_score > _record) _record = _score;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SaveRecord() {
        PlayerPrefs.SetInt(PrefsConfigs.RecordPrefs, _record);
    }

    public int GetRecord() {
        return _record;
    }
}

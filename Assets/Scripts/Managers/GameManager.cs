using UnityEngine;
using System.Collections;

public class GameManager
{
    private static GameManager _instance;

    private int _score = 0;

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
    }

    public int GetScore()
    {
        return _score;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Controllers/Game")]
public class GameController: MonoBehaviour
{
    private GameStore _gameStore;
    private PrefsStore _prefsStore;

    private void Awake()
    {
        OnInit();
        OnInitEvents();
    }

    private void OnInit() 
    {
        _prefsStore = new PrefsStore();
        _gameStore = new GameStore(_prefsStore);
    }

    private void OnInitEvents() 
    {
        Messenger.AddListener(EventsConfig.OnGameOverEvent, OnGameOver);
        Messenger<int>.AddListener(EventsConfig.OnIncreaseScoreEvent, OnIncreaseScore);
    }

    private void OnIncreaseScore(int delta) 
    {
        int score = _gameStore.GetScore();
        int record = _gameStore.GetRecord();
        score += delta;
        if (score > record) _gameStore.SetRecord(score);
        _gameStore.SetScore(score);
    }

    public GameStore GetGameStore() 
    {
        return _gameStore;
    }

    void OnGameOver() 
    {
        int record = _gameStore.GetRecord();
        _prefsStore.PutInteger("record", record);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnGameOverEvent, OnGameOver);
        Messenger<int>.RemoveListener(EventsConfig.OnIncreaseScoreEvent, OnIncreaseScore);
    }
}

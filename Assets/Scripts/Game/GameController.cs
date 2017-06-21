using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Controllers/Game")]
public class GameController: MonoBehaviour
{
    private Dictionary<string, Store<string>> _stores = new Dictionary<string, Store<string>>();

    private void Awake()
    {
        OnInit();
        OnInitEvents();
    }

    private void OnInit() 
    {
        Store<string> prefsStore = new PrefsStore();

        _stores.Add("prefs", prefsStore);
        _stores.Add("game", new GameStore(prefsStore));
    }

    private void OnInitEvents() 
    {
        Messenger.AddListener(EventsConfig.OnGameOverEvent, OnGameOver);
        Messenger<int>.AddListener(EventsConfig.OnIncreaseScoreEvent, OnIncreaseScore);
    }

    private void OnIncreaseScore(int delta) 
    {
        Store<string> gameStore = GetStore("game");
        int score = gameStore.GetInteger("score");
        int record = gameStore.GetInteger("record");
        score += delta;
        if (score > record) gameStore.Put("record", score);
        gameStore.Put("score", score);
    }

    public Store<string> GetStore(string key) 
    {
        return _stores[key];
    }

    void OnGameOver() 
    {
        Store<string> prefsStore = GetStore("prefs");
        Store<string> gameStore = GetStore("game");

        prefsStore.Put("record", gameStore.GetInteger("record"));
        gameStore.Clear();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnGameOverEvent, OnGameOver);
        Messenger<int>.RemoveListener(EventsConfig.OnIncreaseScoreEvent, OnIncreaseScore);
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameStore
{
    private int _score;
    private int _record;

    private Store<string> _prefsStore;

    public GameStore(Store<string> prefsStore) {
        _score = 0;
        _record = prefsStore.GetInteger("record");
        _prefsStore = prefsStore;
    }

    public void SetScore(int score) {
        _score = score;
    }

    public int GetScore() {
        return _score;
    }

    public void SetRecord(int record) {
        _record = record;
    }

    public int GetRecord() {
        return _record;
    }
}

using UnityEngine;
using System.Collections;

public class PrefsManager: MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(EventsConfig.GameEnd, OnSave);
    }

    void OnSave() 
    {
        GameManager.GetInstance().SaveRecord();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.GameEnd, OnSave);
    }
}

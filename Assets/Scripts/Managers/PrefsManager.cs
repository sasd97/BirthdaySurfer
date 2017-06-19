using UnityEngine;
using System.Collections;

[AddComponentMenu("Managers/Prefs")]
public class PrefsManager: MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(EventsConfig.OnGameOverEvent, OnSave);
    }

    void OnSave() 
    {
        GameManager.GetInstance().SaveRecord();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnGameOverEvent, OnSave);
    }
}

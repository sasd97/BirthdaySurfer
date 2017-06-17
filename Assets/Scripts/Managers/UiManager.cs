using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("Managers/UI Manager")]
public class UiManager: MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text _scoreText;

    [Header("UI Service References")]
    [SerializeField] private Text _debugInfoText;

    private void Awake()
    {
        InitDebugAssemblyInfo();
        Messenger.AddListener(EventsConfig.CollectMagicSphereEvent, OnUpdateScore);
    }

    private void InitDebugAssemblyInfo() {
        if (!Debug.isDebugBuild) {
            Destroy(_debugInfoText);
            return;
        }

        string text = string.Format(
            "Debug Build Info\nFor developers purposes only\nBuild <b>{0}</b>\nVersion <b>{1}</b>\nA.Dadukin, 2017",
            Application.buildGUID,
            Application.version
        );

        _debugInfoText.text = text;
    }

    private void OnUpdateScore() 
    {
        int score = GameManager.GetInstance().GetScore();
        _scoreText.text = string.Format("Score: <b>{0}</b>", score);
    }
}

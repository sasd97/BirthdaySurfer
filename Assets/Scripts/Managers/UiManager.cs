using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("Managers/UI Manager")]
public class UiManager: MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _currentMusicText;
    [SerializeField] private Text _distanceText;

    private void Awake()
    {
        OnUpdateScore();
        Messenger.AddListener(EventsConfig.CollectMagicSphereEvent, OnUpdateScore);
        Messenger<string>.AddListener(EventsConfig.NextSong, OnUpdateCurrentMusic);
        Messenger<float>.AddListener(EventsConfig.PlayerDistanceChanedEvent, OnDistanceChanged);
    }

    private void OnDistanceChanged(float distance) {
        _distanceText.text = string.Format("<b>{0:0.00}</b> m", distance / 100);
    }

    private void OnUpdateScore() 
    {
        int score = GameManager.GetInstance().GetScore();
        int record = GameManager.GetInstance().GetRecord();
        _scoreText.text = string.Format("Score: <b>{0}</b>\nRecord: <b>{1}</b>", score, record);
    }

    private void OnUpdateCurrentMusic(string title) 
    {
        _currentMusicText.text = string.Format("Currently playing:  <i>{0}</i>", title);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.CollectMagicSphereEvent, OnUpdateScore);
        Messenger<string>.RemoveListener(EventsConfig.NextSong, OnUpdateCurrentMusic);
        Messenger<float>.RemoveListener(EventsConfig.PlayerDistanceChanedEvent, OnDistanceChanged);

}
}

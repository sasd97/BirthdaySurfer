using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("UI/Controllers/Base Game Ui Script")]
public class UiBase: MonoBehaviour
{
    private GameStore _gameStore;

    [Header("Ui References")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _distanceText;

    [Header("Scene References")]
    [SerializeField] private GameController _gameController;

    void Start()
    {
        _gameStore = _gameController.GetGameStore();
        OnScoreLabelDraw(0);

        Messenger<int>.AddListener(EventsConfig.OnIncreaseScoreEvent, OnScoreLabelDraw);
        Messenger<float>.AddListener(EventsConfig.OnPlayerDistanceChanedEvent, OnDistanceLabelDraw);
    }

    private void OnDistanceLabelDraw(float distance) {
        _distanceText.text = string.Format("<b>{0:0.00}</b> m", distance / 10);
    }

    private void OnScoreLabelDraw(int delta) 
    {
        int score = _gameStore.GetScore();
        int record = _gameStore.GetRecord();
        _scoreText.text = string.Format("Score: <b>{0}</b>\nRecord: <b>{1}</b>", score, record);
    }

    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(EventsConfig.OnIncreaseScoreEvent, OnScoreLabelDraw);
        Messenger<float>.RemoveListener(EventsConfig.OnPlayerDistanceChanedEvent, OnDistanceLabelDraw);
    }
}

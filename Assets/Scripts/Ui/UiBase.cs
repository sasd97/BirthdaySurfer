using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("UI/Controllers/Base Game Ui Script")]
public class UiBase: MonoBehaviour
{
    [Header("Ui References")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _distanceText;

    private void Awake()
    {
        OnScoreLabelDraw();

        Messenger.AddListener(EventsConfig.OnCollectMagicSphereEvent, OnScoreLabelDraw);
        Messenger<float>.AddListener(EventsConfig.OnPlayerDistanceChanedEvent, OnDistanceLabelDraw);
    }

    private void OnDistanceLabelDraw(float distance) {
        _distanceText.text = string.Format("<b>{0:0.00}</b> m", distance / 10);
    }

    private void OnScoreLabelDraw() 
    {
        int score = GameManager.GetInstance().GetScore();
        int record = GameManager.GetInstance().GetRecord();
        _scoreText.text = string.Format("Score: <b>{0}</b>\nRecord: <b>{1}</b>", score, record);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnCollectMagicSphereEvent, OnScoreLabelDraw);
        Messenger<float>.RemoveListener(EventsConfig.OnPlayerDistanceChanedEvent, OnDistanceLabelDraw);
    }
}

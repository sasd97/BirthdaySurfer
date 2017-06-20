using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("UI/Controllers/\"Game Over\" Script")]
public class UiGameOverMenu: MonoBehaviour
{
    [Header("Controllers Refereneces")]
	[SerializeField] private AudioController _audioController;

    [Header("Ui References")]
	[SerializeField] private Text _scoreText;
	[SerializeField] private UiFade _sceneFader;
    [SerializeField] private GameObject _gameOverUi;

    [Header("Scene References")]
    [SerializeField] private string _menuSceneName = "MainMenu";

    private void Awake()
    {
        Messenger.AddListener(EventsConfig.OnGameOverEvent, Toggle);
    }

    public void Toggle()
	{
        _scoreText.text = GameManager.GetInstance().GetScore().ToString();
        _gameOverUi.SetActive(!_gameOverUi.activeSelf);

		if (_gameOverUi.activeSelf)
		{
            GameManager.GetInstance().OnReset();
			_audioController.SetVolumeToMin();
            StateManager.GetInstance().OverGame();
        } else {
            _audioController.SetVolumeToMin();
            Time.timeScale = 1.0f;
        }
	}

	public void Retry()
	{
		Toggle();
		GameManager.GetInstance().OnReset();
		StateManager.GetInstance().ReloadState();
        Messenger.Broadcast(EventsConfig.OnUserResetTag);
        _sceneFader.FadeToAsync(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		Toggle();
		_sceneFader.FadeToAsync(_menuSceneName);
	}

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnGameOverEvent, Toggle);
    }
}

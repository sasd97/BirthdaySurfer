using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("UI/Controllers/\"Game Over\" Script")]
public class UiGameOverMenu: MonoBehaviour
{
	private Store<string> _gameStore;

    [Header("Controllers Refereneces")]
	[SerializeField] private AudioController _audioController;

    [Header("Ui References")]
	[SerializeField] private Text _scoreText;
	[SerializeField] private UiFade _sceneFader;
    [SerializeField] private GameObject _gameOverUi;

    [Header("Scene References")]
    [SerializeField] private GameController _gameController;
    [SerializeField] private string _menuSceneName = "MainMenu";

    void Start()
    {
        _gameStore = _gameController.GetStore("game");
        Messenger.AddListener(EventsConfig.OnGameOverEvent, Toggle);
    }

    private void OnScoreDraw() {
        Debug.Log(_gameStore.GetInteger("score"));
        Debug.Log(_gameStore.GetInteger("record"));
		_scoreText.text = _gameStore.GetInteger("score").ToString();
    }

    public void Toggle()
    {
        OnScoreDraw();
        _gameOverUi.SetActive(!_gameOverUi.activeSelf);

        if (_gameOverUi.activeSelf) Over();
        else Resume();
	}

	public void Retry()
	{
        Time.timeScale = 1.0f;
		StateManager.GetInstance().ReloadState();
		Messenger.Broadcast(EventsConfig.OnUserResetTag);
        _sceneFader.FadeToAsync(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		Toggle();
		_sceneFader.FadeToAsync(_menuSceneName);
	}

    private void Over() {
		_audioController.SetVolumeToMin();
		Time.timeScale = 0.0f;
		StateManager.GetInstance().OverGame();
    }

    private void Resume() {
        Time.timeScale = 1.0f;
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnGameOverEvent, Toggle);
    }
}

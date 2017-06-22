using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("UI/Controllers/\"Pause\" Script")]
public class UiPauseMenu: MonoBehaviour
{
	[Header("Controllers Refereneces")]
    [SerializeField] private AudioController _audioController;

    [Header("Ui References")]
	[SerializeField] private Text _currentMusicText;
    [SerializeField] private UiFade _sceneFader;
    [SerializeField] private GameObject _pauseUi;

    [Header("Scene References")]
    [SerializeField] private string _menuSceneName = "MenuScene";
    [SerializeField] private GameController _gameController;

    void Start()
    {
		Messenger<string>.AddListener(EventsConfig.OnNextSong, OnUpdateCurrentMusic);
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	private void OnUpdateCurrentMusic(string title)
	{
        if (_currentMusicText == null) return;
		_currentMusicText.text = string.Format("Currently playing:  <i>{0}</i>", title);
	}

	public void Toggle()
	{
        if (!IsPauseAvailable()) return;
		_pauseUi.SetActive(!_pauseUi.activeSelf);

        if (_pauseUi.activeSelf) Pause();
        else Resume();
	}

	public void Retry()
	{
		Time.timeScale = 1.0f;
        _pauseUi.SetActive(false);
		StateManager.GetInstance().ReloadState();
		Messenger.Broadcast(EventsConfig.OnUserResetTag);
		_sceneFader.FadeToAsync(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		Time.timeScale = 1.0f;
		StateManager.GetInstance().ReloadState();
		Messenger.Broadcast(EventsConfig.OnUserResetTag);
        _sceneFader.FadeToAsync(_menuSceneName);
	}

    private void Pause() {
		_audioController.SetVolumeToMin();
		Time.timeScale = 0.0f;
		StateManager.GetInstance().PauseGame();
    }

    private void Resume() {
		_audioController.SetVolumeToMax();
		Time.timeScale = 1.0f;
		StateManager.GetInstance().ResumeGame();
    }

    private bool IsPauseAvailable() {
        return StateManager.GetInstance().StateIs(StateManager.States.PLAYED, StateManager.States.PAUSED);
    }

    private void OnDestroy()
    {
		Messenger<string>.RemoveListener(EventsConfig.OnNextSong, OnUpdateCurrentMusic);
    }
}

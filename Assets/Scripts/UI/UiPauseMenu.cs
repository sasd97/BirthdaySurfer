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
    [SerializeField] private string _menuSceneName = "MainMenu";

    private void Awake()
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

		if (_pauseUi.activeSelf)
		{
            _audioController.SetVolumeToMin();
            StateManager.GetInstance().PauseGame();
		}
		else
		{
            _audioController.SetVolumeToMax();
            StateManager.GetInstance().ResumeGame();
		}
	}

	public void Retry()
	{
		Toggle();
        StateManager.GetInstance().ReloadState();
        _sceneFader.FadeToAsync(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		Toggle();
        _sceneFader.FadeToAsync(_menuSceneName);
	}

    private bool IsPauseAvailable() {
        return StateManager.GetInstance().StateIs(StateManager.States.PLAYED, StateManager.States.PAUSED);
    }

    private void OnDestroy()
    {
		Messenger<string>.RemoveListener(EventsConfig.OnNextSong, OnUpdateCurrentMusic);
    }
}

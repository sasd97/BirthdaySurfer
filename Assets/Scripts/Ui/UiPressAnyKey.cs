using UnityEngine;

[AddComponentMenu("UI/Controllers/\"Press Any Key\" Script")]
public class UiPressAnyKey: MonoBehaviour
{
    private PlayerInput _input;

	[Header("Controllers Refereneces")]
    [SerializeField] private AudioController _audioController;
	[SerializeField] private GameController _gameController;

	[Header("Ui References")]
    [SerializeField] private UiFade _sceneFader;
    [SerializeField] private GameObject _pressAnyKeyUi;

	void Start()
	{
		Time.timeScale = 0.0f;
        _input = new KeyboardInput();
	}

	void Update()
	{
        if (!_input.IsKeyDown()) return;

        _sceneFader.FadeInAsync();
        _audioController.PlayNext();

        this.enabled = false;
        Destroy(_pressAnyKeyUi.gameObject);

        StateManager.GetInstance().StartGame();
        Time.timeScale = 1.0f;
	}
}

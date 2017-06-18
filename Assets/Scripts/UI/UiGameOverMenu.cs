using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiGameOverMenu: MonoBehaviour
{
    public GameObject ui;
    public Text score;
    public AudioController audioController;
    public UiFade sceneFader;

    private void Awake()
    {
        Messenger.AddListener(EventsConfig.GameEnd, Toggle);
    }

    public void Toggle()
	{
        score.text = GameManager.GetInstance().GetScore().ToString();
        ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
            GameManager.GetInstance().OnReset();
			audioController.LowVolume();
			Time.timeScale = 0f;
		}
		else
		{
			audioController.UpVolume();
			Time.timeScale = 1f;
		}
	}

	public void Retry()
	{
		Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		Toggle();
		sceneFader.FadeTo("");
	}

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.GameEnd, Toggle);
    }
}

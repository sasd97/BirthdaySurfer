using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiPauseMenu: MonoBehaviour
{
	public GameObject ui;
	public string menuSceneName = "MainMenu";
    public AudioController audioController;

    public UIFade sceneFader;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle()
	{
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
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
        sceneFader.FadeTo(menuSceneName);
	}

}

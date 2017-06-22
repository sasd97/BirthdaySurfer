using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenu: MonoBehaviour {

    public void LoadGame() {
        SceneManager.LoadSceneAsync("RunScene");
    }

    public void QuitApp() {
        Application.Quit();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugCanvasDrawer: MonoBehaviour
{
    [Header("UI Service References")]
    public GameObject ui;
	[SerializeField] private Text _debugInfoText;

    private void Awake()
    {
        if (!Debug.isDebugBuild) {
            Destroy(ui);
            return;
        }

        OnDebug(60.0f);
        Messenger<float>.AddListener(EventsConfig.DebugFpsEvent, OnDebug);
    }

	private void OnDebug(float fps)
	{

		string text = string.Format(
            "Debug Build Info\nFor developers purposes only\nFPS: <b>{0:0.0}</b>\n" +
            "Platform <b>{1}</b>\nBuild <b>{2}</b>\nVersion <b>{3}</b>\nA.Dadukin, 2017",
            fps,
            Application.platform,
			Application.buildGUID,
			Application.version
		);

		_debugInfoText.text = text;
	}

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(EventsConfig.DebugFpsEvent, OnDebug);
    }
}

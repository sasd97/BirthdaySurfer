using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Controllers/Debug Info Script")]
public class UiDebug: MonoBehaviour
{
    private float _defaultFpsValue = 60.0f;

    [Header("UI Service References")]
    [SerializeField] private GameObject _debugUi;
	[SerializeField] private Text _debugInfoText;

    private void Awake()
    {
        if (!Debug.isDebugBuild) {
            Destroy(_debugUi);
            return;
        }

        OnDebugLabelDraw(_defaultFpsValue);

        Messenger<float>.AddListener(EventsConfig.OnFpsChangedEvent, OnDebugLabelDraw);
    }

    private void OnDebugLabelDraw(float fps)
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
        Messenger<float>.RemoveListener(EventsConfig.OnFpsChangedEvent, OnDebugLabelDraw);
    }
}

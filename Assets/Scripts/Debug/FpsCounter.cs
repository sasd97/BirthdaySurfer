using UnityEngine;
using System.Collections;

public class FpsCounter: MonoBehaviour
{
    private float _deltaTime;

    private void Awake()
    {
        if (Debug.isDebugBuild) return;
        Destroy(this);
    }

    void Update()
	{
		_deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;

        if (!IsActive()) return;
		float fps = 1.0f / _deltaTime;

        Messenger<float>.Broadcast(EventsConfig.OnFpsChangedEvent, fps);
	}

    private bool IsActive() {
        return StateManager.GetInstance().StateIs(
            StateManager.States.PLAYED
        );
    }
}

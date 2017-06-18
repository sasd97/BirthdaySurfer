using UnityEngine;
using System.Collections;

public class FpsCounter: MonoBehaviour
{

	float deltaTime = 0.0f;

    private void Awake()
    {
        if (Debug.isDebugBuild) return;
        Destroy(this);
    }

    void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
        Messenger<float>.Broadcast(EventsConfig.DebugFpsEvent, fps);
	}

    
}

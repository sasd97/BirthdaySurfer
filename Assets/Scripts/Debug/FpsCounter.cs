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
        if (System.Math.Abs(deltaTime) < 0.001) {
            Messenger<float>.Broadcast(EventsConfig.DebugFpsEvent, 60.0f);
            return;
        }
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
        Messenger<float>.Broadcast(EventsConfig.DebugFpsEvent, fps);
	}

    
}

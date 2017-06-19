using UnityEngine;

public class PlayerDistanceTracker: MonoBehaviour
{
	void Update()
	{
        Messenger<float>.Broadcast(EventsConfig.OnPlayerDistanceChanedEvent, this.transform.position.z);       
	}
}

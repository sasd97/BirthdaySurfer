using UnityEngine;

public class PlayerDistanceTracker: MonoBehaviour
{
    private void FixedUpdate()
	{
        Messenger<float>.Broadcast(EventsConfig.OnPlayerDistanceChanedEvent, this.transform.position.z);       
	}
}

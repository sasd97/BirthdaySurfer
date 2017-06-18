using UnityEngine;
using System.Collections;

public class PlayerDistanceTracker: MonoBehaviour
{
	void Update()
	{
        Messenger<float>.Broadcast(EventsConfig.PlayerDistanceChanedEvent, this.transform.position.z);       
	}
}

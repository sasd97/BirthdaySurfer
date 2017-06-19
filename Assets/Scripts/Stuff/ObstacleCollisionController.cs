using UnityEngine;
using System.Collections;

[AddComponentMenu("Platform/Stuff/Obtacle Collision Controller")]
public class ObstacleCollisionController: MonoBehaviour
{
	[Header("Collision Attributes")]
	[SerializeField] private string _collisionObjectTag = TagsConfig.PlayerTag;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != _collisionObjectTag) return;
        Debug.Log("Game is ended");
        Messenger.Broadcast(EventsConfig.OnGameOverEvent);
	}
}

using UnityEngine;
using System.Collections;

[AddComponentMenu("Platform/Stuff/Magic Sphere Collision Controller")]
public class MagicSphereCollisionController: MonoBehaviour
{
    [Header("Events Attributes")]
    [SerializeField] private string _collectMagicSphereEvent = EventsConfig.CollectMagicSphereEvent;

	[Header("Destroy Attributes")]
	[SerializeField] private string _destroyerTag = TagsConfig.PlayerTag;
    [SerializeField] private GameObject _participlePrefab;
    [SerializeField] private long participleObjectLifeDuration = 3L;

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag != _destroyerTag) return;
        GameObject p = Instantiate(_participlePrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
        Destroy(p, participleObjectLifeDuration);
        GameManager.GetInstance().IncreaseScore();
        Messenger.Broadcast(EventsConfig.CollectMagicSphereEvent);
	}
}

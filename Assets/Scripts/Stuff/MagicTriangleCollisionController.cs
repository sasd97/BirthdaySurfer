using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Platform/Stuff/Twice Magic Sphere Collision Controller")]
public class MagicTriangleCollisionController: MonoBehaviour
{
	[Header("Destroy Attributes")]
	[SerializeField] private string _destroyerTag = TagsConfig.PlayerTag;
	[SerializeField] private GameObject _participlePrefab;
	[SerializeField] private long _participleObjectLifeDuration = 3L;
	[SerializeField] private long _magicSphereDeadDuration = 1L;

	private AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != _destroyerTag) return;

		_audioSource.Play();
        GameObject p = Instantiate(_participlePrefab, this.transform.position, Quaternion.identity);

		Destroy(this.gameObject, _magicSphereDeadDuration);
		Destroy(p, _participleObjectLifeDuration);

		Messenger<int>.Broadcast(EventsConfig.OnIncreaseScoreEvent, 2);
	}
}

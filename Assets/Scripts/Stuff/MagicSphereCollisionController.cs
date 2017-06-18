using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Platform/Stuff/Magic Sphere Collision Controller")]
public class MagicSphereCollisionController: MonoBehaviour
{
	[Header("Destroy Attributes")]
	[SerializeField] private string _destroyerTag = TagsConfig.PlayerTag;
    [SerializeField] private GameObject _participlePrefab;
    [SerializeField] private long participleObjectLifeDuration = 3L;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
	{
        if (other.tag != _destroyerTag) return;
		_audioSource.Play();
        GameObject p = Instantiate(_participlePrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject, 1L);
        Destroy(p, participleObjectLifeDuration);
        GameManager.GetInstance().IncreaseScore();
        Messenger.Broadcast(EventsConfig.CollectMagicSphereEvent);
	}
}

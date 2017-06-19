using UnityEngine;
using System.Collections;

[AddComponentMenu("Player/Movement Forward Script")]
public class PlayerForwardMovementController: MonoBehaviour
{

	[Header("Character Attributes")]
	[SerializeField] private float _characterSpeed = 6.0f;
    [SerializeField] private float _speedFactor = 1.0f;
    [SerializeField] private float _speedLimit = 120.0f;

    private void Awake()
    {
        Messenger.AddListener(EventsConfig.OnCollectMagicSphereEvent, IncreaseSpeed);
    }

    void IncreaseSpeed() {
        _characterSpeed = Mathf.Clamp(_characterSpeed + _speedFactor, _characterSpeed, _speedLimit);
    }

    void Update()
	{
		this.transform.Translate(MoveForward());
	}

	private Vector3 MoveForward()
	{
		return Vector3.forward * _characterSpeed * Time.deltaTime;
	}
}

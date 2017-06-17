using UnityEngine;
using System.Collections;

[AddComponentMenu("Player/Movement Forward Script")]
public class PlayerForwardMovementController: MonoBehaviour
{

	[Header("Character Attributes")]
	[SerializeField] private float _characterSpeed = 6.0f;

	void Update()
	{
		this.transform.Translate(MoveForward());
	}

	private Vector3 MoveForward()
	{
		return Vector3.forward * _characterSpeed * Time.deltaTime;
	}
}

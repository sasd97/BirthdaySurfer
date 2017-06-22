using UnityEngine;
using System.Collections;

public class MagicTriangleRotationController: MonoBehaviour
{

    [SerializeField] private Vector3 _rotationVector = new Vector3(0, 3, 0);

	void Update()
	{
        this.transform.Rotate(_rotationVector);
	}
}

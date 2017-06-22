using UnityEngine;
using System.Collections;

public class MagicSphereGenerator : Generator
{
    private GameObject[] _prefabs;
    private Transform[] _positions;

    public MagicSphereGenerator(GameObject[] prefabs, Transform[] positions)
    {
        _prefabs = prefabs;
        _positions = positions;
    }

    public GameObject Generate(string tag, Transform parent)
    {
        int factor = Random.Range(0, 100);
        if (factor < 85) return null;
        if (factor < 97) return SpawOrdinarySphere(parent);
        return SpawSpecialSphere(parent);
    }

    private GameObject SpawOrdinarySphere(Transform parent) {
		GameObject obstacle = Object.Instantiate(_prefabs[0], GetPosition());
		obstacle.transform.parent = parent;
		return obstacle;
    }

	private GameObject SpawSpecialSphere(Transform parent)
	{
		GameObject obstacle = Object.Instantiate(_prefabs[1], GetPosition());
		obstacle.transform.parent = parent;
		return obstacle;
	}

    private Transform GetPosition()
    {
        int randomSpawnPoint = Random.Range(0, _positions.Length);
        return _positions[randomSpawnPoint];
    }
}

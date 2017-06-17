using UnityEngine;
using System.Collections;

public class ObstacleGenerator: Generator
{
    private GameObject _prefab;
    private Transform[] _positions;

    public ObstacleGenerator(GameObject prefab, Transform[] positions) {
        _prefab = prefab;
        _positions = positions;
    }

    public GameObject Generate(string tag, Transform parent)
    {
        if (Random.Range(0, 100) < 70) return null;
        GameObject obstacle = GameObject.Instantiate(_prefab, GetPosition());
        obstacle.transform.parent = parent;
        return obstacle;
    }

    private Transform GetPosition() {
        int randomSpawnPoint = Random.Range(0, _positions.Length);
        return _positions[randomSpawnPoint];
    }
}

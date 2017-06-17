using UnityEngine;
using System.Collections;
using System;

public class ObstacleGenerator: Generator
{
    private GameObject _prefab;

    public ObstacleGenerator(GameObject prefab) {
        _prefab = prefab;
    }

    public GameObject Generate(string tag)
    {
        GameObject obstacle = GameObject.Instantiate(_prefab);
        //wall.transform.parent = platform.transform;
        //wall.transform.Translate(new Vector3(Random.Range(-15, 15), 0, 5));
        return obstacle;
    }
}

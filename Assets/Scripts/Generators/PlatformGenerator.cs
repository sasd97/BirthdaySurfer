using UnityEngine;
using System.Collections;
using System;

public class PlatformGenerator: Generator
{
    private GameObject _prefab;
	private int _spawnedOffset = 0;
	private string _incomingPlatformTag = TagsConfig.IncomingPlatfromTag;
	private string _outgoingPlatfromTag = TagsConfig.OutgoingPlatfromTag;

    public PlatformGenerator(GameObject prefab) {
        _prefab = prefab;
    }

    public GameObject Generate(string tag)
    {
        Vector3 position = CalculatePosition();
        GameObject platform = GameObject.Instantiate(_prefab, position, Quaternion.identity);
        platform.gameObject.tag = tag;

        _spawnedOffset++;
        return platform;
    }

    private Vector3 CalculatePosition() {
        return new Vector3(0, 0, _spawnedOffset * 10);
    }
}

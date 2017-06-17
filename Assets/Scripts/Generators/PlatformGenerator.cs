using UnityEngine;
using System.Collections;
using System;

public class PlatformGenerator: Generator
{
    private GameObject _prefab;

    public PlatformGenerator(GameObject prefab) {
        _prefab = prefab;
    }

    public GameObject Generate(string tag, Transform parent)
    {
        GameObject platform = GameObject.Instantiate(_prefab, parent.position, parent.rotation);
        platform.gameObject.tag = tag;
        return platform;
    }
}

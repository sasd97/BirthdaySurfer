﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Platform/Spawn Controller")]
public class PlatformSpawnController: MonoBehaviour {

    private Generator _platformGenerator;

	[Header("Platform Spawn Attributes")]
    [SerializeField] int _platfromGroupSize = 7;
    [SerializeField] private GameObject _platformPrefab;

    [Header("Stuff Spawn Attributes")]
    [SerializeField] private GameObject _obstaclePrefab;

    private void Awake()
    {
        _platformGenerator = new PlatformGenerator(_platformPrefab);
        Messenger.AddListener(EventsConfig.PlatformSpawnEvent, SpawnPlatformGroup);
        SpawnPlatformGroup();
    }

    void SpawnPlatformGroup() {
        for (int i = 0; i < _platfromGroupSize; i++) SpawnPlatform(i);
    }

    private GameObject SpawnPlatform(int iteration) {
        GameObject platform = _platformGenerator.Generate(ChoosePlatfromTag(iteration));

        return platform;
    }

    private string ChoosePlatfromTag(int iteration) {
        if (iteration == 0) return TagsConfig.IncomingPlatfromTag;
        if (iteration == _platfromGroupSize - 1) return TagsConfig.OutgoingPlatfromTag;
        return TagsConfig.PlatfromTag;
    }
}

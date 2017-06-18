﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Platform/Spawn Controller")]
public class PlatformSpawnController: MonoBehaviour {

    private Generator _platformGenerator;
    private Generator _obstacleGenerator;
    private Generator _magicSphereGenerator;
    private int itemsGeneratedCounter = 0;

    [Header("Controller Attributes")]
    [SerializeField] private Vector3 _translationVector = new Vector3(0, 0, 10);

	[Header("Platform Spawn Attributes")]
    [SerializeField] int _platfromGroupSize = 7;
    [SerializeField] private GameObject _platformPrefab;

    [Header("Stuff Spawn Attributes")]
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Transform[] _obstaclePositions;
    [SerializeField] private GameObject _magicSpherePrefab;
    [SerializeField] private Transform[] _magicSpherePositions;

    private void Awake()
    {
        _platformGenerator = new PlatformGenerator(_platformPrefab);
        _obstacleGenerator = new ObstacleGenerator(_obstaclePrefab, _obstaclePositions);
        _magicSphereGenerator = new MagicSphereGenerator(_magicSpherePrefab, _magicSpherePositions);
        Messenger.AddListener(EventsConfig.PlatformSpawnEvent, SpawnPlatformGroup);
    }

    void SpawnPlatformGroup() {
        for (int i = 0; i < _platfromGroupSize; i++) SpawnPlatform(i);
    }

    private GameObject SpawnPlatform(int iteration) {
        GameObject platform = _platformGenerator.Generate(ChoosePlatfromTag(iteration), this.transform);
        GameObject obstacle = _obstacleGenerator.Generate(TagsConfig.ObstacleTag, platform.transform);
        GameObject magicSphere = _magicSphereGenerator.Generate(TagsConfig.MagicSphereTag, platform.transform);
        FinilizeGeneration();
        return platform;
    }

    private string ChoosePlatfromTag(int iteration) {
        if (iteration == 0) return TagsConfig.IncomingPlatfromTag;
        if (iteration == _platfromGroupSize - 1) return TagsConfig.OutgoingPlatfromTag;
        return TagsConfig.PlatfromTag;
    }

	private void FinilizeGeneration()
	{
		itemsGeneratedCounter++;
		this.transform.Translate(_translationVector);
	}

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.PlatformSpawnEvent, SpawnPlatformGroup);
    }
}

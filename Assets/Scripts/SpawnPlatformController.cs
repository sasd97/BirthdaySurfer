using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformController : MonoBehaviour {

    public const string SPAWN_BARRIER_EVENT = "spawn.barrier";
	public const string IN_GAMEOBJECT_TAG = "InBarrier";
	public const string OUT_GAMEOBJECT_TAG = "OutBarrier";

	[SerializeField] private GameObject _barrierPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] int counter = 7;
    int offset = 0;
    string inTag = IN_GAMEOBJECT_TAG;
    string outTag = OUT_GAMEOBJECT_TAG;

    private void Awake()
    {
        Messenger.AddListener(SPAWN_BARRIER_EVENT, OnSpawn);
        GenerateRow();
    }

    void GenerateRow() {
        for (int i = 0; i < counter; i++) {
            GenerateBarrier(i);
        }
        offset += counter;
    }

    private void OnSpawn() {
        GenerateRow();
    }

    private GameObject GenerateBarrier(int i) {
		GameObject clone = Instantiate(_barrierPrefab, new Vector3(0, 0, (i + offset) * 10), this.transform.rotation);
		if (i == 0) MarkAsIn(clone);
		if (i == counter - 1) MarkAsOut(clone);

        GameObject wall = Instantiate(_wallPrefab, clone.transform.position, clone.transform.rotation);
        wall.transform.parent = clone.transform;
        wall.transform.Translate(new Vector3(Random.Range(-15, 15), 0, 5));

        return clone;
    }

    private void MarkAsIn(GameObject clone) {
        clone.gameObject.tag = inTag;
    }

	private void MarkAsOut(GameObject clone)
	{
        clone.gameObject.tag = outTag;
	}
}

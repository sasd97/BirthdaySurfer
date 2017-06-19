using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/Movement Stabilizer")]
public class PlayerStabilizer: MonoBehaviour {

    public GameObject player;

    private void Awake()
    {
        Messenger.AddListener(EventsConfig.OnGameOverEvent, OnGameOver);
    }

    void OnGameOver() 
    {
        player.gameObject.tag = TagsConfig.Untagged;
    }

    void Update () {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
	}

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnGameOverEvent, OnGameOver);
    }
}

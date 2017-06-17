using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/Movement Stabilizer")]
public class PlayerStabilizer: MonoBehaviour {

	void Update () {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
	}
}

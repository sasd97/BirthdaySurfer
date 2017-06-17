﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/Collision Controller")]
public class PlayerCollisionController: MonoBehaviour {

    void OnTriggerExit(Collider col) {
        foreach (var rule in PlayerConfigs.CollisionRules) {
            if (rule.IsApplicable(col.tag)) rule.Apply();
        }
    }
}

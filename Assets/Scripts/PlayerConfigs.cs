using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerConfigs
{
    public static List<CollisionRule<string>> CollisionRules = new List<CollisionRule<string>> {
        new SpawnObstaclesRule()
	};
}

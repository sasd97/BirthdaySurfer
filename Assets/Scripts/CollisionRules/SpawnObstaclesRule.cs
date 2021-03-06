using UnityEngine;
using System.Collections;
using System;

public class SpawnObstaclesRule: CollisionRule<string>
{
    public void Apply()
    {
        Messenger.Broadcast(EventsConfig.OnPlatformSpawnEvent); 
    }

    public bool IsApplicable(string data)
    {
        return data == TagsConfig.IncomingPlatfromTag;
    }
}

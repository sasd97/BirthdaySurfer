using UnityEngine;
using System.Collections;
using System;

public class SpawnBarriersRule: Rule<string>
{
    public void Apply()
    {
        Messenger.Broadcast(SpawnPlatformController.SPAWN_BARRIER_EVENT); 
    }

    public bool IsApplicable(string data)
    {
        return data == SpawnPlatformController.IN_GAMEOBJECT_TAG;
    }
}

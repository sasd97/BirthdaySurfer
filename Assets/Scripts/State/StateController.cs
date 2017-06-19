using UnityEngine;
using System.Collections;

public class StateController: MonoBehaviour
{
    private void Awake()
    {
        StateManager.GetInstance();
    }
}

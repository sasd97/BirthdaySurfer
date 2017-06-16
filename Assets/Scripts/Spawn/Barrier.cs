using UnityEngine;
using System.Collections;

public class Barrier: MonoBehaviour
{

    private static long _destroyDelay = 5L;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") Destroy(this.gameObject, _destroyDelay);
    }
}

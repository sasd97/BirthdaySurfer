using UnityEngine;

[AddComponentMenu("Platform/Collision Controller")]
public class PlatformCollisionController: MonoBehaviour
{
    [Header("Destroy Attributes")]
    [SerializeField] private string _destroyerTag = TagsConfig.PlayerTag;
    [SerializeField] private long _destroyDelay = 3L;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _destroyerTag) Destroy(this.gameObject, _destroyDelay);
    }
}

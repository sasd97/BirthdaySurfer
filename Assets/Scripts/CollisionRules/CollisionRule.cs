using UnityEngine;
using System.Collections;

public interface CollisionRule<in T>
{
    bool IsApplicable(T data);
    void Apply();
}

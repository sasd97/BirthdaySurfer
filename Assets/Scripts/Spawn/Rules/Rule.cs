using UnityEngine;
using System.Collections;

public interface Rule<in T>
{
    bool IsApplicable(T data);
    void Apply();
}

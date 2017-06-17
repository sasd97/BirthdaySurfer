using UnityEngine;
using System.Collections;

public interface Generator
{
    GameObject Generate(string tag, Transform parent);
}

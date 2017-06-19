using UnityEngine;
using System.Collections;

public interface PlayerInput
{
    Direction GetDirection();

    bool IsKeyDown();
    bool IsKeyDown(KeyCode keyCode);
}

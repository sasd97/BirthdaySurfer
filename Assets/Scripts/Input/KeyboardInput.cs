using UnityEngine;
using System.Collections;
using System;

public class KeyboardInput: PlayerInput
{
	private KeyCode _leftKeyCode = KeyCode.LeftArrow;
	private KeyCode _rightKeyCode = KeyCode.RightArrow;

    public Direction GetDirection()
    {
        if (Input.GetKeyDown(_leftKeyCode)) return Direction.LEFT;
        if (Input.GetKeyDown(_rightKeyCode)) return Direction.RIGHT;
        return Direction.UNKNOWN;
    }
}

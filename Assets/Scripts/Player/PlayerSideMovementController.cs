using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMovementController: MonoBehaviour {

    [Header("Area Attributes")]
    [SerializeField] private int _characterStartPositionIndex = 1;
    [SerializeField] private int[] _characterPositions;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new KeyboardInput();
    }

    void Start() {
        this.transform.position = new Vector3(_characterPositions[_characterStartPositionIndex], 0.1f, 0);
    }

	void Update() {
        if (IsMovingLeft())
        {
            this.transform.position = MoveLeft();
        }

        if (IsMovingRight()) 
        {
            this.transform.position = MoveRight();    
        }
	}

    private bool IsMovingLeft() {
        return _playerInput.GetDirection() == Direction.LEFT;
    }

    private bool IsMovingRight() {
        return _playerInput.GetDirection() == Direction.RIGHT;
    }

    private Vector3 MoveLeft() {
        _characterStartPositionIndex = Mathf.Clamp(_characterStartPositionIndex - 1, 0, _characterPositions.Length - 1);
        Debug.Log(_characterStartPositionIndex);
        return new Vector3(_characterPositions[_characterStartPositionIndex], 0, this.transform.position.z);
    }

    private Vector3 MoveRight() {
        _characterStartPositionIndex = Mathf.Clamp(_characterStartPositionIndex + 1, 0, _characterPositions.Length - 1);
        Debug.Log(_characterStartPositionIndex);
        return new Vector3(_characterPositions[_characterStartPositionIndex], 0, this.transform.position.z);
    }
}

using System;
using UnityEngine;

public class StateManager
{
	private static StateManager _instance;

    public enum States {
        AWAITING_START,
        PLAYED,
        PAUSED,
        OVERED
    }

    private States _currentState;

	private StateManager()
	{
        _currentState = States.AWAITING_START;
	}

	public static StateManager GetInstance()
	{
		if (_instance == null) _instance = new StateManager();
		return _instance;
	}

    public States GetState() {
        return _currentState;
    }

    public void StartGame() {
        UnlockWhile(States.AWAITING_START);
        SwitchStateTo(States.PLAYED);
    }

    public void ResumeGame() {
        UnlockWhile(States.PAUSED);
        SwitchStateTo(States.PLAYED);
    }

    public void PauseGame() {
        UnlockWhile(States.PLAYED);
        SwitchStateTo(States.PAUSED);
    }

    public void OverGame() {
		UnlockWhile(States.PLAYED);
        SwitchStateTo(States.OVERED);
    }

    public void ReloadState() {
        SwitchStateTo(States.AWAITING_START);
    }

	public bool StateIs(params States[] states)
	{
		foreach (States state in states)
		{
			if (_currentState == state) return true;
		}

        return false;
	}

    public bool StateNot(params States[] states) {
		foreach (States state in states)
		{
            if (_currentState == state) return false;
		}

        return true;
    }

    public bool IsGameStarted() {
        return _currentState != States.AWAITING_START;
    }

    public bool IsGameRunning() {
        return _currentState == States.PLAYED;
    }

    private void SwitchStateTo(States state) {
        _currentState = state;
        Debug.Log("Current state is: " + state);
        //Messenger<States>.Broadcast(EventsConfig.OnGameStateChangedEvent, _currentState);
    }

    private void UnlockWhile(params States[] states) {
        bool isUnlocked = false;

        foreach(States state in states) {
            if (_currentState == state) {
                isUnlocked = true;
                break;
            }
        }

        if (!isUnlocked) {
            string exceptionMessage = string.Format("Illegal switching from {0}", _currentState);
            throw new InvalidOperationException(exceptionMessage); 
        }
    } 
}

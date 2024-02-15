using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public PlayerState currentState;
    public void Initialize(PlayerState startState)
    {
        currentState = startState;
        currentState.Enter();
    }


    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[Serializable]
public class TileStateMachine
{
    public IState CurrentState { get; private set; }

    public IdleState IdleState;
    public SelectedState SelectedState;
    public DestroyState DestroyState;
    public FallingState FallingState;

    public TileStateMachine(TileScript tileScript)
    {
        this.IdleState = new IdleState(tileScript);
        this.SelectedState = new SelectedState(tileScript);
        this.DestroyState = new DestroyState(tileScript);
        this.FallingState = new FallingState(tileScript);
    }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}

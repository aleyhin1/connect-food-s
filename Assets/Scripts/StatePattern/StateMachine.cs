using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[Serializable]
public class StateMachine
{
    public IState CurrentState { get; private set; }

    public IdleState IdleState;
    public SelectedState SelectedState;

    public Animator animator;

    public StateMachine(EmptyTileScript emptyTile)
    {
        this.IdleState = new IdleState(emptyTile);
        this.SelectedState = new SelectedState(emptyTile);
    }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter(animator);
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit(animator);
        CurrentState = nextState;
        nextState.Enter(animator);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}

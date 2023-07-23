using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[Serializable]
public class TileStateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    public IdleState IdleState;
    public SelectedState SelectedState;

    public Animator animator;
    public StackVariable SelectedTiles;

    private void Start()
    {
        IdleState = new IdleState(this);
        SelectedState = new SelectedState(this);
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

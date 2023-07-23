using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private TileStateMachine tileStateMachine;

    public IdleState(TileStateMachine tileStateMachine)
    {
        this.tileStateMachine = tileStateMachine;
    }

    public void Enter()
    {
        tileStateMachine.animator.SetBool("IsSelected", false);
    }

    public void Update()
    {
        // Here we add logic to detect if the conditions exist to
        // transition to another state
    }

    public void Exit()
    {
        tileStateMachine.animator.SetBool("IsSelected", true);
    }
}

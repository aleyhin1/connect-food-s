using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private EmptyTileScript emptyTile;

    public IdleState(EmptyTileScript emptyTile)
    {
        this.emptyTile = emptyTile;
    }

    public void Enter(Animator animator)
    {
        animator.SetBool("IsSelected", false);
    }

    public void Update()
    {
        // Here we add logic to detect if the conditions exist to
        // transition to another state
    }

    public void Exit(Animator animator)
    {
        animator.SetBool("IsSelected", true);
    }
}
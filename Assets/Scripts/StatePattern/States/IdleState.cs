using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private TileScript tileScript;

    public IdleState(TileScript tileScript)
    {
        this.tileScript = tileScript;
    }

    public void Enter()
    {
        //tileScript.animator.SetBool("IsSelected", false);
    }

    public void Update()
    {
        // Here we add logic to detect if the conditions exist to
        // transition to another state
    }

    public void Exit()
    {
        //tileScript.animator.SetBool("IsSelected", true);
    }
}

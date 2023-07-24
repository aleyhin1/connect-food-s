using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State, IState
{

    public IdleState(TileScript tileScript) : base(tileScript) { }

    public void Enter()
    {

    }

    public void Update()
    {
        // Here we add logic to detect if the conditions exist to
        // transition to another state
    }

    public void Exit()
    {

    }
}

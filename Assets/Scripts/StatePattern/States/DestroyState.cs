using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyState : State, IState
{

    public DestroyState(TileScript tileScript) : base(tileScript) { }

    public void Enter()
    {
        TileScript.TileDestroyed.Invoke();
        TileScript.SelectedFruit.Type = string.Empty;
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

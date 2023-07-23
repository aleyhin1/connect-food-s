using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedState : IState
{
    private TileScript tileScript;

    public SelectedState(TileScript tileScript)
    {
        this.tileScript = tileScript;
    }

    public void Enter()
    {
        tileScript.animator.SetBool("isSelected", true);
        tileScript.SelectedTiles.Stack.Push(tileScript.gameObject);
        Debug.Log(tileScript.SelectedTiles.Stack.Count);
    }

    public void Update()
    {
        // Here we add logic to detect if the conditions exist to
        // transition to another state
    }

    public void Exit()
    {
        tileScript.animator.SetBool("isSelected", false);
    }
}

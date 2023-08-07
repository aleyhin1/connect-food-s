using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State, IState
{

    public IdleState(TileScript tileScript) : base(tileScript) { }

    public void Enter()
    {
        TileScript.StartCoroutine(TileScript.SetNeighboursPerpetually());
    }

    public void Update()
    {

    }

    public void Exit()
    {
        TileScript.StopCoroutine(TileScript.SetNeighboursPerpetually());
    }
}

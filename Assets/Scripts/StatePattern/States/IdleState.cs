using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State, IState
{

    public IdleState(TileScript tileScript) : base(tileScript) { }

    public void Enter()
    {
        TileScript.Animator.SetBool("isSelected", false);
        TileScript.Rope.SetActive(false);
    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}

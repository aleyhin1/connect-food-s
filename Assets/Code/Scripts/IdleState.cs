using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State, IState
{

    public IdleState(TileScript tileScript) : base(tileScript) { }

    public void Enter()
    {
        TileScript.Animator.SetBool("isSelected", false);
        RopeController ropeController = TileScript.Rope.GetComponent<RopeController>();
        ropeController.StopAllCoroutines();
        TileScript.Rope.SetActive(false);
        TileScript.IsWalkable = false;
    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}

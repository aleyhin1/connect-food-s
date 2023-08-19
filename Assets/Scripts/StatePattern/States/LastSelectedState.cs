using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSelectedState : State, IState
{

    public LastSelectedState(TileScript tileScript) : base(tileScript) { }

    private RopeController _ropeController;

    public void Enter()
    {
        TileScript.Animator.SetBool("isSelected", true);
        TileScript.SelectedFruit.Type = TileScript.gameObject.tag;
        TileScript.SetWalkableOnNeighbours();
        TileScript.SelectedTiles.Tiles.Push(TileScript.gameObject);
        TileScript.Rope.SetActive(true);
        _ropeController = TileScript.gameObject.GetComponentInChildren<RopeController>();
        _ropeController.StartCoroutine(_ropeController.MoveCoroutine);
    }

    public void Update()
    {
        if (TileScript.SelectedTiles.Tiles.Count == 0)
        {
            TileScript.TileStateMachine.TransitionTo(TileScript.TileStateMachine.DestroyState);
        }
        else if (TileScript.SelectedTiles.Tiles.Peek() != TileScript.gameObject)
        {
            TileScript.TileStateMachine.TransitionTo(TileScript.TileStateMachine.SelectedState);
        }
        else if (Input.touchCount == 0)
        {
            TileScript.TileStateMachine.TransitionTo(TileScript.TileStateMachine.DestroyState);
        }
    }

    public void Exit()
    {
        _ropeController.StopCoroutine(_ropeController.MoveCoroutine);
    }

}
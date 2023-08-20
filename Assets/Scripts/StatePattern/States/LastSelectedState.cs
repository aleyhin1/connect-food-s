using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSelectedState : State, IState
{

    public LastSelectedState(TileScript tileScript) : base(tileScript) { }

    private RopeController _ropeController;

    public void Enter()
    {
        if (TileScript.SelectedTiles.Positions.Contains(TileScript.transform.position))
        {
            OnSelectedTwice();
        }

        SetLastSelected();
    }

    public void Update()
    {
        if (TileScript.SelectedTiles.Positions.Peek() != TileScript.transform.position)
        {
            TileScript.TileStateMachine.TransitionTo(TileScript.TileStateMachine.SelectedState);
        }
    }

    public void Exit()
    {
        _ropeController.StopCoroutine(_ropeController.MoveCoroutine);
        _ropeController.StopCoroutine(_ropeController.ResizeCoroutine);
    }

    private void OnSelectedTwice()
    {
        while (TileScript.SelectedTiles.Positions.Peek() != TileScript.transform.position)
        {
            GameObject lastTile = TileScript.SelectedTiles.Tiles.Pop();
            TileScript lastTileScript = lastTile.GetComponent<TileScript>();
            lastTileScript.TileStateMachine.TransitionTo(lastTileScript.TileStateMachine.IdleState);

            TileScript.SelectedTiles.Positions.Pop();
        }

        TileScript.SelectedTiles.Tiles.Pop();
        TileScript.SelectedTiles.Positions.Pop();
        _ropeController.StopAllCoroutines();
        TileScript.Rope.SetActive(false);
    }

    private void SetLastSelected()
    {
        TileScript.Animator.SetBool("isSelected", true);
        TileScript.SelectedFruit.Type = TileScript.gameObject.tag;
        TileScript.SetWalkableOnNeighbours();
        TileScript.SelectedTiles.Tiles.Push(TileScript.gameObject);
        TileScript.SelectedTiles.Positions.Push(TileScript.transform.position);
        TileScript.Rope.SetActive(true);
        _ropeController = TileScript.gameObject.GetComponentInChildren<RopeController>();
        _ropeController.StartCoroutine(_ropeController.MoveCoroutine);
        _ropeController.StartCoroutine(_ropeController.ResizeCoroutine);
    }
}
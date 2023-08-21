using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        if (TileScript.SelectedTiles.Tiles.Count > 1)
        {
            SetPreviousTileToSelected();
        }
    }

    public void Update()
    {

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
            Debug.Log("I'm in OnSelectedTwice loop");
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

    private void SetPreviousTileToSelected()
    {
        Stack<GameObject> tempStack = new Stack<GameObject>(new Stack<GameObject>(TileScript.SelectedTiles.Tiles));
        tempStack.Pop();

        GameObject previousTile = tempStack.Peek();
        TileScript previousTileScript = previousTile.GetComponent<TileScript>();
        previousTileScript.TileStateMachine.TransitionTo(previousTileScript.TileStateMachine.SelectedState);
    }
}
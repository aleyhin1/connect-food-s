using UnityEngine;

public class SelectedState : State , IState
{
    public SelectedState(TileScript tileScript): base(tileScript) { }

    private RopeController _ropeController;

    public void Enter()
    {
        _ropeController = TileScript.gameObject.GetComponentInChildren<RopeController>();
        _ropeController.Lock(TileScript.SelectedTiles.Tiles.Peek());
    }

    public void Update()
    {
        if (Input.touchCount == 0)
        {
            TileScript.TileStateMachine.TransitionTo(TileScript.TileStateMachine.DestroyState);
        }
    }

    public void Exit()
    {
        TileScript.Animator.SetBool("isSelected", false);

        if (TileScript.SelectedTiles.Tiles.Count  > 0)
        {
            TileScript.SelectedTiles.Tiles.Clear();
        }
    }


}

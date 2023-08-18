using UnityEngine;

public class SelectedState : State , IState
{
    public SelectedState(TileScript tileScript): base(tileScript) { }

    public void Enter()
    {
       
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

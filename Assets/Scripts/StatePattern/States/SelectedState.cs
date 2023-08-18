using UnityEngine;

public class SelectedState : State , IState
{
    public SelectedState(TileScript tileScript): base(tileScript) { }

    public void Enter()
    {
        TileScript.Animator.SetBool("isSelected", true);
        TileScript.SelectedFruit.Type = TileScript.gameObject.tag;
        TileScript.SetWalkableOnNeighbours();
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
    }


}

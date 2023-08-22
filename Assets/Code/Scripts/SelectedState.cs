using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SelectedState : State , IState
{
    public SelectedState(TileScript tileScript): base(tileScript) { }

    private RopeController _ropeController;

    public void Enter()
    {
        _ropeController = TileScript.gameObject.GetComponentInChildren<RopeController>();
        _ropeController.Lock(TileScript.SelectedTiles.Positions.Peek());
        TileScript.SetUnwalkableOnNeighbours();
    }

    public void Update()
    {
        
    }

    public void Exit()
    {

    }


}

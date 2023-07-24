using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class SelectedState : State , IState
{
    public SelectedState(TileScript tileScript): base(tileScript) { }

    public void Enter()
    {
        tileScript.animator.SetBool("isSelected", true);
        AddTileToList();
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        tileScript.animator.SetBool("isSelected", false);
        RemoveTileFromList();
    }


}

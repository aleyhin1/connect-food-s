using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class SelectedState : State , IState
{
    public SelectedState(TileScript tileScript): base(tileScript) { }

    public void Enter()
    {
        TileScript.Animator.SetBool("isSelected", true);
        AddTileToList();
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        TileScript.Animator.SetBool("isSelected", false);
        RemoveTileFromList();
    }


}

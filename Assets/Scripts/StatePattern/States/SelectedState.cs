using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class SelectedState : IState
{
    private TileScript tileScript;

    public SelectedState(TileScript tileScript)
    {
        this.tileScript = tileScript;
    }

    public void Enter()
    {
        tileScript.animator.SetBool("isSelected", true);
        var newObjWithPos = new ObjectWithPosition(tileScript.gameObject, tileScript.gameObject.transform.position);
        tileScript.SelectedTiles.objectList.Add(newObjWithPos);

        Debug.Log(tileScript.SelectedTiles.objectList.Count);
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        tileScript.animator.SetBool("isSelected", false);
    }
}

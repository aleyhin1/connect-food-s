using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : IState
{
    protected TileScript tileScript;

    public State(TileScript tileScript)
    {
        this.tileScript = tileScript;
    }

    protected void AddTileToList()
    {
        var newObjWithPos = new ObjectWithPosition(tileScript.gameObject, tileScript.gameObject.transform.position);
        tileScript.SelectedTiles.objectList.Add(newObjWithPos);
    }

    protected void RemoveTileFromList()
    {
        var newObjWithPos = new ObjectWithPosition(tileScript.gameObject, tileScript.gameObject.transform.position);
        tileScript.SelectedTiles.objectList.Remove(newObjWithPos);
    }

}

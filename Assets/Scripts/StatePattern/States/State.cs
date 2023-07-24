using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : IState
{
    protected TileScript TileScript;

    public State(TileScript tileScript)
    {
        this.TileScript = tileScript;
    }

    protected void AddTileToList()
    {
        var newObjWithPos = new ObjectWithPosition(TileScript.gameObject, TileScript.gameObject.transform.position);
        TileScript.SelectedTiles.List.Add(newObjWithPos);
    }

    protected void RemoveTileFromList()
    {
        var newObjWithPos = new ObjectWithPosition(TileScript.gameObject, TileScript.gameObject.transform.position);
        TileScript.SelectedTiles.List.Remove(newObjWithPos);
    }

}

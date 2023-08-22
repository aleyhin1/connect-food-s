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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelectedTiles : ScriptableObject
{
    public Stack<GameObject> Tiles;

    SelectedTiles()
    {
        Tiles = new Stack<GameObject>();
    }
}

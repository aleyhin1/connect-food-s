using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelectedTiles : ScriptableObject
{
    public Stack<GameObject> Tiles;
    public Stack<Vector3> Positions;

    SelectedTiles()
    {
        Tiles = new Stack<GameObject>();
        Positions = new Stack<Vector3>();
    }
}

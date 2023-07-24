using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjectList")]
public class ObjectList : ScriptableObject
{
    public List<ObjectWithPosition> List = new List<ObjectWithPosition>();
}

public class ObjectWithPosition
{
    public GameObject Object;
    public Vector3 Position;

    public ObjectWithPosition(GameObject obj, Vector3 pos)
    {
        Object = obj;
        Position = pos;
    }
}
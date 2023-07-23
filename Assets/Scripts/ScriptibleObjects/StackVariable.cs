using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class StackVariable : ScriptableObject
{
    public Stack<GameObject> Stack = new Stack<GameObject>();
}

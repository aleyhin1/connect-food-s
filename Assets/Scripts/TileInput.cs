using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileInput : MonoBehaviour
{
    public UnityEvent TileSelectedEvent;

    private void OnMouseEnter()
    {
        TileSelectedEvent.Invoke();
    }
}

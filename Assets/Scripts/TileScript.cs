using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public Animator animator;
    public ObjectList SelectedTiles;

    private TileStateMachine tileStateMachine;

    private void Awake()
    {
        tileStateMachine = new TileStateMachine(this);
    }

    private void Start()
    {
        tileStateMachine.Initialize(tileStateMachine.IdleState);
    }

    private void OnMouseEnter()
    {
        tileStateMachine.TransitionTo(tileStateMachine.SelectedState);
    }

    private void Update()
    {
        tileStateMachine.Update();
        Debug.Log(SelectedTiles.objectList.Count);
    }
}

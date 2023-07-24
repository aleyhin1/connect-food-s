using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public Animator Animator;
    public ObjectList SelectedTiles;

    private TileStateMachine _tileStateMachine;

    private void Awake()
    {
        _tileStateMachine = new TileStateMachine(this);
    }

    private void Start()
    {
        _tileStateMachine.Initialize(_tileStateMachine.IdleState);
    }

    private void OnMouseEnter()
    {
        _tileStateMachine.TransitionTo(_tileStateMachine.SelectedState);
    }

    private void Update()
    {
        _tileStateMachine.Update();
    }
}

    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public Animator Animator;
    public ObjectList SelectedTiles;
    public SelectedFruit SelectedFruit;

    private GameObject[] _neighbourTiles;
    private TileStateMachine _tileStateMachine;

    private Vector2[] _raycastVectors = { Vector2.left, Vector2.left + Vector2.up, Vector2.up, Vector2.up + Vector2.right
    , Vector2.right, Vector2.right + Vector2.down, Vector2.down, Vector2.down + Vector2.left};

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
        GetNeighbourTiles();
        if (SelectedFruit.Type == string.Empty || gameObject.tag == SelectedFruit.Type)
        {
            _tileStateMachine.TransitionTo(_tileStateMachine.SelectedState);
            SelectedFruit.Type = gameObject.tag;
        }
    }

    private void Update()
    {
        _tileStateMachine.Update();
    }

    private void GetNeighbourTiles()
    {
        foreach (Vector2 directionVectors in _raycastVectors)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, directionVectors, 1f);
            if (hitInfo != false)
            {
                Debug.Log(hitInfo.collider.gameObject.tag);
            }
        }
        
    }
}

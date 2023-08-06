    using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public Animator Animator;
    public ObjectList SelectedTiles;
    public SelectedFruit SelectedFruit;
    public GameObject[] NeighbourTiles;
    public bool IsWalkable = false;

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
        SetNeighbourTiles();
    }

    private void OnMouseEnter()
    {
        if (SelectedFruit.Type == string.Empty)
        {
            _tileStateMachine.TransitionTo(_tileStateMachine.SelectedState);
            SelectedFruit.Type = gameObject.tag;
            SetWalkableOnNeighbours();
        }
        else if (gameObject.tag == SelectedFruit.Type && IsWalkable)
        {
            _tileStateMachine.TransitionTo(_tileStateMachine.SelectedState);
            SetWalkableOnNeighbours();
        }
    }

    private void Update()
    {
        _tileStateMachine.Update();
    }

    private void SetNeighbourTiles()
    {
        foreach (Vector2 directionVectors in _raycastVectors)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, directionVectors, 1f);
            if (hitInfo != false)
            {
                NeighbourTiles = NeighbourTiles.Append(hitInfo.collider.gameObject).ToArray();
            }
        }
    }

    private void SetWalkableOnNeighbours()
    {
        foreach (GameObject tile in NeighbourTiles)
        {
            if (tile.tag == SelectedFruit.Type)
            {
                tile.GetComponent<TileScript>().IsWalkable = true;
            }
        }
    }
}

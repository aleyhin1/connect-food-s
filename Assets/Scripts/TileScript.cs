using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public Animator Animator;
    public ObjectList SelectedTiles;
    public SelectedFruit SelectedFruit;
    public List<GameObject> NeighbourTiles;
    public bool IsWalkable = false;
    public UnityEvent TileDestroyed;

    public TileStateMachine TileStateMachine;
    private Vector2[] _raycastVectors = { Vector2.left, Vector2.left + Vector2.up, Vector2.up, Vector2.up + Vector2.right
    , Vector2.right, Vector2.right + Vector2.down, Vector2.down, Vector2.down + Vector2.left};

    private void Awake()
    {
        TileStateMachine = new TileStateMachine(this);
    }

    private void Start()
    {
        TileStateMachine.Initialize(TileStateMachine.IdleState);
    }

    private void OnMouseEnter()
    {
        if (Input.touchCount > 0)
        {
            if (SelectedFruit.Type == string.Empty)
            {
                TileStateMachine.TransitionTo(TileStateMachine.SelectedState);
                SelectedFruit.Type = gameObject.tag;
                SetWalkableOnNeighbours();
            }
            else if (gameObject.tag == SelectedFruit.Type && IsWalkable)
            {
                TileStateMachine.TransitionTo(TileStateMachine.SelectedState);
                SetWalkableOnNeighbours();
            }
        }
    }

    private void Update()
    {
        TileStateMachine.Update();
    }

    private void SetNeighbourTiles()
    {
        foreach (Vector2 directionVectors in _raycastVectors)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, directionVectors, 1f);
            if (hitInfo != false)
            {
                NeighbourTiles.Add(hitInfo.collider.gameObject);
            }
        }
    }

    public IEnumerator SetNeighboursPerpetually()
    {
        while (gameObject != null)
        {
            yield return new WaitForSeconds(.5f);


            SetNeighbourTiles();
        }
    }

    private void SetWalkableOnNeighbours()
    {
        foreach (GameObject tile in NeighbourTiles)
        {
            if (tile != null && tile.tag == SelectedFruit.Type)
            {
                tile.GetComponent<TileScript>().IsWalkable = true;
            }
        }
    }
}

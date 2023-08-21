using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public Animator Animator;
    public SelectedFruit SelectedFruit;
    public List<GameObject> NeighbourTiles;
    public bool IsWalkable = false;
    public UnityEvent OnTileDestroy;
    public TileStateMachine TileStateMachine;
    public SelectedTiles SelectedTiles;
    public GameObject Rope;
    

    private BoardSpawner _boardSpawner;
    private Vector2[] _raycastVectors = { Vector2.left, Vector2.left + Vector2.up, Vector2.up, Vector2.up + Vector2.right
    , Vector2.right, Vector2.right + Vector2.down, Vector2.down, Vector2.down + Vector2.left};

    private void Awake()
    {
        TileStateMachine = new TileStateMachine(this);
    }

    private void Start()
    {
        TileStateMachine.Initialize(TileStateMachine.IdleState);
        _boardSpawner = FindObjectOfType<BoardSpawner>();
    }

    
    private void OnMouseEnter()
    {
        if (Input.touchCount > 0)
        {
            if (SelectedFruit.Type == string.Empty)
            {
                TileStateMachine.TransitionTo(TileStateMachine.LastSelectedState);
            }

            else if (gameObject.tag == SelectedFruit.Type && IsWalkable)
            {
                TileStateMachine.TransitionTo(TileStateMachine.LastSelectedState);
            }
        }
    }

    private void OnMouseUp()
    {
        if (SelectedTiles.Tiles.Count >= 3)
        {
            foreach (var tile in SelectedTiles.Tiles)
            {
                tile.GetComponent<TileScript>().OnTileDestroy.Invoke();
            }
        }
        else
        {
            foreach(var tile in SelectedTiles.Tiles)
            {
                TileScript tileScript = tile.GetComponent<TileScript>();
                tileScript.TileStateMachine.TransitionTo(tileScript.TileStateMachine.IdleState);
            }
        }

        SelectedTiles.Tiles.Clear();
        SelectedTiles.Positions.Clear();
        SelectedFruit.Type = string.Empty;
    }

    private void Update()
    {
        TileStateMachine.Update();
    }

    public void SetWalkableOnNeighbours()
    {
        foreach (Vector2 directionVectors in _raycastVectors)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, directionVectors, 1f);

            if (hitInfo != false && (hitInfo.collider.tag == SelectedFruit.Type))
            {
                hitInfo.collider.GetComponent<TileScript>().IsWalkable = true;
            }
        }
    }

    public void TileDestroyed()
    {
        SelectedFruit.Type = string.Empty;
        _boardSpawner.FillBoard(transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BoardManagerScript : MonoBehaviour
{
    public static BoardManagerScript Instance;    
    public GameObject[] FruitTiles;
    public SpriteRenderer EmptyTile;
    public int xSize, ySize;
    public ObjectList ActiveTiles;

    private GameObject[,] _tiles;      

    public bool IsShifting { get; set; }     

    void Start()
    {
        Instance = GetComponent<BoardManagerScript>();     

        Vector2 offset = EmptyTile.bounds.size;
        CreateBoard(offset.x, offset.y);
    }

    private void CreateBoard(float xOffset, float yOffset)
    {
        _tiles = new GameObject[xSize, ySize];

        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {      
            for (int y = 0; y < ySize; y++)
            {
                GameObject randomTile = FruitTiles[Random.Range(0, FruitTiles.Length)];
                Vector3 newPosition = new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0);

                GameObject newTile = Instantiate(randomTile, newPosition, randomTile.transform.rotation);

                _tiles[x, y] = newTile;

                AddTileToList(newTile, newPosition);

            }
        }
    }

    private void AddTileToList(GameObject tile, Vector3 position)
    {
        var objWithPosition = new ObjectWithPosition(tile, position);
        ActiveTiles.List.Add(objWithPosition);
    }
}

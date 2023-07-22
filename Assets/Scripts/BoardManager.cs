using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;    
    public GameObject[] FruitTiles;
    public SpriteRenderer EmptyTile;
    public int xSize, ySize;     

    private GameObject[,] _tiles;      

    public bool IsShifting { get; set; }     

    void Start()
    {
        instance = GetComponent<BoardManager>();     

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

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{
    private ObjectPool _objectPool;
    private float[] _spawnPositionsX = {-2,-1,0,1,2,2,1,0,-1,-2};

    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();

        StartCoroutine(InitializeBoard());
    }

    private IEnumerator InitializeBoard()
    {
        yield return new WaitForSeconds(.1f);

        int tileCount = _objectPool.BoardDimension.x * _objectPool.BoardDimension.y;

        for (int i = 0; i < tileCount; i++)
        {
            float spawnPositionXIndex = _spawnPositionsX[i % 10];
            _objectPool.GetPooledObject().transform.position = new Vector2(spawnPositionXIndex, 6);

            yield return new WaitForSeconds(.1f);
        }
    }

    public void FillBoard(Vector2 tilePosition)
    {
        _objectPool.GetPooledObject().transform.position = new Vector2( tilePosition.x, 6 + tilePosition.y);
    }
}

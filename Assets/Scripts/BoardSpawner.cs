using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{
    private ObjectPool _objectPool;
    private float[] _spawnPositionsX = {-1.5f,-.75f,0,.75f,1.5f,1.5f,.75f,0,-.75f,-1.5f};

    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();

        StartCoroutine(InitializeBoard());
    }

    private IEnumerator InitializeBoard()
    {
        yield return new WaitForSeconds(1);

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

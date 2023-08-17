using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{
    private ObjectPool _objectPool;
    private int[] _spawnPositionsX = {-2,-1,0,1,2,2,1,0,-1,-2};

    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();

        StartCoroutine(FillBoard());
    }

    private IEnumerator FillBoard()
    {
        yield return new WaitForSeconds(.1f);

        int tileCount = _objectPool.BoardDimension.x * _objectPool.BoardDimension.y;

        for (int i = 0; i < tileCount; i++)
        {
            int spawnPositionXIndex = _spawnPositionsX[i % 10];
            _objectPool.GetPooledObject().transform.position = new Vector2(spawnPositionXIndex, 6);

            yield return new WaitForSeconds(.1f);
        }
    }

}

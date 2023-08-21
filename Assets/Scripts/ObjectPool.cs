using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public PooledObject[] TilePrefabs;
    public Vector2Int BoardDimension;
    // Determines how much bigger the Poolsize should be than the Boardsize
    public int _poolMultiplier;

    private PooledObject _objectToPool;

    // store the pooled objects in a collection
    private Queue<PooledObject> _queue;
    private int _destroyedTilesCount = 0;

    private void Start()
    {
        SetupPool();
    }

    // creates the pool (invoke when the lag is not noticeable)
    private void SetupPool()
    {
        _queue = new Queue<PooledObject>();
        PooledObject instance = null;

        for (int i = 0; i < GetPoolSize(); i++)
        {
            instance = Instantiate(GetRandomTile(), transform);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            _queue.Enqueue(instance);
        }
    }

    // returns the first active GameObject from the pool
    public PooledObject GetPooledObject()
    {
        // if the pool is not large enough, instantiate a new PooledObjects
        if (_queue.Count == 0)
        {
            PooledObject newInstance = Instantiate(_objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }

        // otherwise, just grab the next one from the list
        PooledObject nextInstance = _queue.Dequeue();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        _queue.Enqueue(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }

    private PooledObject GetRandomTile()
    {
        int randomIndex = Random.Range(0, TilePrefabs.Length);
        PooledObject randomTile = TilePrefabs[randomIndex];
        return randomTile;
    }

    private int GetPoolSize()
    {
        int poolSize = BoardDimension.x * BoardDimension.y * _poolMultiplier;
        return poolSize;
    }

    public void ShuffleQueue()
    {
        _destroyedTilesCount++;
        Debug.Log("Destroyed tiles count is : " + _destroyedTilesCount);
        if (_destroyedTilesCount  >= BoardDimension.x * BoardDimension.y)
        {
            List<PooledObject> tempList = _queue.ToList<PooledObject>();
            ShuffleList(tempList);
            _queue = new Queue<PooledObject>(tempList);
            Debug.Log("I shuffled the pool");
            _destroyedTilesCount = 0;
        }
    }

    //Fischer-Yates shuffle alghoritm
    private static void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            int randIndex = Random.Range(i, n);
            T temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }
}
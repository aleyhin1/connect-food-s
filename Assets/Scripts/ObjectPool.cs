using System.Collections;
using System.Collections.Generic;
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
            instance.name += i;
            instance.GetComponent<TileScript>().ObjectReference = instance.gameObject;
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
}
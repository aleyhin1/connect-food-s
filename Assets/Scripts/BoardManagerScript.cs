using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BoardManagerScript : MonoBehaviour
{
    private IDictionary<Vector3, Vector3> nodeParents = new Dictionary<Vector3, Vector3>();
    public IDictionary<Vector3, bool> walkablePositions;


    //Vector3 FindShortestPath(Vector3 startPosition, Vector3 goalPosition)
    //{
    //    Queue<Vector3> queue = new Queue<Vector3>();
    //    HashSet<Vector3> visitedNodes = new HashSet<Vector3>();
    //    queue.Enqueue(startPosition);

    //    while (queue.Count > 0)
    //    {
    //        Vector3 currentNode = queue.Dequeue();
    //        if (currentNode == goalPosition)
    //        {
    //            return currentNode;
    //        }

    //        IList<Vector3> nodes = GetWalkableNodes(currentNode);

    //        foreach (Vector3 node in nodes)
    //        {
    //            if (!visitedNodes.Contains(node))
    //            {
    //                visitedNodes.Add(node);
    //                nodeParents.Add(node, currentNode);
    //                queue.Enqueue(node);
    //            }
    //        }
    //    }

    //    return startPosition;
    //}

    //public void SetWalkableTiles(Vector3 initialTilePosition)
    //{
    //    for (int i = 0; i < 8; i++)
    //    {
    //        if (ActiveTiles.List.Contains(_, initialTilePosition + )
    //    }
    //}
}

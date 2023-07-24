using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleTileDestroyer : MonoBehaviour
{
    public ObjectList SelectedTiles;

    private int _duplicateIndex;



    //void Update()
    //{
    //    if (SelectedTiles.List.Count > 1)
    //    {
            

            

    //        if (SelectedTiles.List.Count != SelectedTiles.List.Distinct().Count())
    //        {
    //            Debug.Log("I found duplicates!");
    //            var duplicatePosition = SelectedTiles.List[SelectedTiles.List.Count - 1].Position;

    //            for (int i = 0; i < SelectedTiles.List.Count -1; i++)
    //            {
    //                if (SelectedTiles.List[i].Position == duplicatePosition)
    //                {
    //                    _duplicateIndex = i;
    //                    Debug.Log("Duplicate Index is = " + _duplicateIndex);
    //                    break;
    //                }
    //            }

    //            for (int i = SelectedTiles.List.Count -1; i > _duplicateIndex; i--)
    //            {
    //                SelectedTiles.List.Remove(SelectedTiles.List[i]);
    //            }
    //        }
    //    }
    //}
}

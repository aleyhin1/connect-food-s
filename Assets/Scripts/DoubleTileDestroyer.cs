using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleTileDestroyer : MonoBehaviour
{
    public ObjectList SelectedTiles;

    private int duplicateIndex;



    void Update()
    {
        if (SelectedTiles.objectList.Count > 1)
        {
            

            

            if (SelectedTiles.objectList.Count != SelectedTiles.objectList.Distinct().Count())
            {
                Debug.Log("I found duplicates!");
                var duplicatePosition = SelectedTiles.objectList[SelectedTiles.objectList.Count - 1].Position;

                for (int i = 0; i < SelectedTiles.objectList.Count -1; i++)
                {
                    if (SelectedTiles.objectList[i].Position == duplicatePosition)
                    {
                        duplicateIndex = i;
                        Debug.Log("Duplicate Index is = " + duplicateIndex);
                        break;
                    }
                }

                for (int i = SelectedTiles.objectList.Count -1; i > duplicateIndex; i--)
                {
                    SelectedTiles.objectList.Remove(SelectedTiles.objectList[i]);
                }
            }
        }
    }
}

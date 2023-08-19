using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _tilePosition;
    public IEnumerator MoveCoroutine;

    private void OnEnable()
    {
        _camera = Camera.main;
        _tilePosition = GetComponentInParent<TileScript>().transform.position;
        MoveCoroutine = Move();
    }

    private IEnumerator Move()
    {
        for (;;)
        {
            if (Input.touchCount != 0)
            {
                Vector2 inputPositionScreenPoint = Input.GetTouch(0).position;
                Vector2 inputPosition = _camera.ScreenToWorldPoint(inputPositionScreenPoint);

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, FindAngle(inputPosition));
                
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public void Lock(GameObject lastSelectedTile)
    {
        Vector2 lastSelectedTilePosition = lastSelectedTile.transform.position;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, FindAngle(lastSelectedTilePosition));
    }

    private float FindAngle(Vector2 targetPosition)
    {
       
        Vector2 DifferenceVector = targetPosition - _tilePosition;
        float angleInRadian = Mathf.Atan2(DifferenceVector.y, DifferenceVector.x);
        float angle = Mathf.Rad2Deg * angleInRadian;
        return angle;
    }
}

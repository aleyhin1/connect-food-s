using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _tilePosition;
    public IEnumerator MoveCoroutine;
    public IEnumerator ResizeCoroutine;

    private void OnEnable()
    {
        _camera = Camera.main;
        _tilePosition = GetComponentInParent<TileScript>().transform.position;
        MoveCoroutine = Move();
        ResizeCoroutine = Resize();
    }

    private IEnumerator Move()
    {
        for (;;)
        {
            if (Input.touchCount != 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, FindAngle(GetInputVector()));
                
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public void Lock(GameObject lastSelectedTile)
    {
        Vector2 lastSelectedTilePosition = lastSelectedTile.transform.position;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, FindAngle(lastSelectedTilePosition));
        transform.localScale = new Vector3(1.5f, .25f, 1);
    }

    private float FindAngle(Vector2 targetPosition)
    {
       
        Vector2 DifferenceVector = targetPosition - _tilePosition;
        float angleInRadian = Mathf.Atan2(DifferenceVector.y, DifferenceVector.x);
        float angle = Mathf.Rad2Deg * angleInRadian;
        return angle;
    }

    private IEnumerator Resize()
    {
        for (;;)
        {
            if (Input.touchCount != 0)
            {
                Vector2 resizeVector = GetInputVector() - _tilePosition;
                float resizeMultiplier = resizeVector.magnitude;
                resizeMultiplier = Mathf.Clamp(resizeMultiplier, 0, 1.75f);

                transform.localScale = new Vector3(resizeMultiplier, .25f, 1);

                yield return new WaitForEndOfFrame();
            }
        }
    }

    private Vector2 GetInputVector()
    {
        Vector2 inputPositionScreenPoint = Input.GetTouch(0).position;
        Vector2 inputPosition = _camera.ScreenToWorldPoint(inputPositionScreenPoint);

        return inputPosition;
    }
}

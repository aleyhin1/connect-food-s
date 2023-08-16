using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSetting : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private TileScript _tileScript;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _tileScript = GetComponent<TileScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.attachedRigidbody.bodyType != RigidbodyType2D.Dynamic)
        {
            _tileScript.TileStateMachine.TransitionTo(_tileScript.TileStateMachine.IdleState);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _tileScript.TileStateMachine.TransitionTo(_tileScript.TileStateMachine.FallingState);
    }
}

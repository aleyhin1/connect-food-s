using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingState : State, IState
{
    public FallingState(TileScript tileScript) : base(tileScript) { }

    private Rigidbody2D _rigidbody;

    public void Enter()
    {
        _rigidbody = TileScript.gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public void Update()
    {

    }

    public void Exit()
    {
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

}

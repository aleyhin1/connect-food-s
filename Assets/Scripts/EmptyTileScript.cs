using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileScript : MonoBehaviour
{
    private Animator animator;
    private StateMachine stateMachine;


    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        stateMachine = new StateMachine(this);
        stateMachine.animator = this.animator;
    }

    private void Start()
    {
        stateMachine.Initialize(stateMachine.IdleState);
    }

}

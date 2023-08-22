using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent GameEvent;
    public UnityEvent OnEventTrigger;

    void OnEnable()
    {
        GameEvent.AddListener(this);
    }
    void OnDisable()
    {
        GameEvent.RemoveListener(this);
    }
    public void OnEventTriggered()
    {
        OnEventTrigger.Invoke();
    }
}

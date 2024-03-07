using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Signal listener behaviour
public class SignalListener : MonoBehaviour
{
    public SignalSender signal;
    public UnityEvent signalEvent;

    // Invoke event for listener's object
    public void OnSignalRaised() 
    {
        signalEvent.Invoke();
    }

    // Call RegisterListener function on enable
    private void OnEnable() 
    {
        signal.RegisterListener(this);
    }

    // Call DeRegisterListener function on disable
    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}

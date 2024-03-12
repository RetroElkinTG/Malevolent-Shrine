using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Signal system behaviour
[CreateAssetMenu]
public class SignalSender : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();
    
    // Call OnSignalRaised function for each listener
    public void Raise()
    {
        for (int index = listeners.Count - 1; index >= 0; index --) 
        {
            listeners[index].OnSignalRaised();
        }
    }

    // Add listener to list
    public void RegisterListener(SignalListener listener) 
    {
        listeners.Add(listener);
    }

    // Remove listener from list
    public void DeRegisterListener(SignalListener listener) 
    {
        listeners.Remove(listener);
    }
}
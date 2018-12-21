using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCommandHandler : MonoBehaviour
{
    
    [Tooltip("Is this interaction only sent once?")]
    public bool isOneShot = false;
    [Tooltip("If this (value) > 0, the interaction will only be sent once every (value) seconds.")]
    public float coolDown = 0;
    [Tooltip("Delay in seconds before the interaction is sent to the target.")]
    public float startDelay = 0;

    protected bool isTriggered = false;
    float startTime = 0;

    // Implement this in subclass to define the actiosn that handler should do
    public abstract void PerformInteraction();

    public virtual void OnInteraction()
    {
        if (isOneShot && isTriggered) return;
        isTriggered = true;
        if (coolDown > 0)
        {
            if (Time.time > startTime + coolDown)
            {
                startTime = Time.time + startDelay;
                ExecuteInteraction();
            }
        }
        else
            ExecuteInteraction();
    }

    void ExecuteInteraction()
    {
        if (startDelay > 0)
            Invoke("PerformInteraction", startDelay);
        else
            PerformInteraction();
    }
}


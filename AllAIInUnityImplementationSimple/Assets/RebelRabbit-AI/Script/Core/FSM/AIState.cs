using System;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public String stateName { get { return this.GetType().Name; } }
    public virtual void EnterState(AIController controller)
    {
        Debug.Log("Entering state: " + this.GetType().Name);
    }

    public virtual void UpdateState(AIController controller)
    {
        Debug.Log("Updating state: " + this.GetType().Name);
    }

    public virtual void ExitState(AIController controller)
    {
        Debug.Log("Exiting state: " + this.GetType().Name);
    }

    public abstract void CheckTransitions(AIController controller);
}


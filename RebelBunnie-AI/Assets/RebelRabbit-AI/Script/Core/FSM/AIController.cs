
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class AIController : MonoBehaviour
{
    public AIState currentState;
    public AIState remainState;
    public List<AIState> states = new List<AIState>();
    public NavMeshAgent navMeshAgent;
    
     private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent not found on this GameObject!");
        }
        // Set the initial state (e.g., Idle).
        if (states.Count > 0)
        {
            TransitionToState(states[0]);
        }
    }

 private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
            currentState.CheckTransitions(this);
        }
    }

    public void TransitionToState(AIState nextState)
    {
        if (nextState != remainState)
        {
            if (currentState != null)
            {
                currentState.ExitState(this);
            }
            currentState = nextState;
            currentState.EnterState(this);
        }
    }
    public void AddState(AIState state)
    {
        states.Add(state);
    }
    public AIState GetState(string stateName)
    {
        foreach (AIState state in states)
        {
            if (state.stateName == stateName)
            {
                return state;
            }
        }
        return null;
    }
}

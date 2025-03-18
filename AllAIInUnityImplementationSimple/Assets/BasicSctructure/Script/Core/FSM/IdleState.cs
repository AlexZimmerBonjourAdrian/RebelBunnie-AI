using UnityEngine;
using UnityEngine.AI;

public class IdleState : AIState
{
    public float idleDuration = 3f; // How long the AI will stay idle.
    private float timer = 0f;

    public override void EnterState(AIController controller)
    {
        base.EnterState(controller);
        timer = 0f;
        // Stop the NavMeshAgent when entering the idle state.
        if (controller.navMeshAgent != null)
        {
            controller.navMeshAgent.isStopped = true;
        }
    }

    public override void UpdateState(AIController controller)
    {
        base.UpdateState(controller);
        timer += Time.deltaTime;

        // Check if it's time to transition to the Patrol state.
        if (timer >= idleDuration)
        {
            controller.TransitionToState(controller.GetState("PatrolState"));
        }
    }

    public override void ExitState(AIController controller)
    {
        base.ExitState(controller);
        // Resume the NavMeshAgent when exiting the idle state.
        if (controller.navMeshAgent != null)
        {
            controller.navMeshAgent.isStopped = false;
        }
    }
    public override void CheckTransitions(AIController controller)
    {
        //no need to check transitions in this state
    }
}


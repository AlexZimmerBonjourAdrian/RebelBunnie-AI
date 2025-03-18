using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AIState
{
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private bool goingForward = true;

    public override void EnterState(AIController controller)
    {
        base.EnterState(controller);
        // Set the first waypoint as the destination.
        if (waypoints.Count > 0)
        {
            controller.navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    public override void UpdateState(AIController controller)
    {
        base.UpdateState(controller);
        // Check if the AI has reached the current waypoint.
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending && waypoints.Count > 0)
        {
            // Move to the next waypoint.
            if (goingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = waypoints.Count - 2; // Go back to the second to last waypoint
                    goingForward = false; // Change direction
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1; // Go back to the second waypoint
                    goingForward = true; // Change direction
                }
            }
            controller.navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    public override void ExitState(AIController controller)
    {
        base.ExitState(controller);
    }
    public override void CheckTransitions(AIController controller)
    {
        //no need to check transitions in this state
    }
}



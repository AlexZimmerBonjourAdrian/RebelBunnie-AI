using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform target; // The target the AI will move towards. Drag and drop the target object in the Inspector.
    public float stoppingDistance = 1.0f; // How close the AI should get to the target before stopping.

    private NavMeshAgent agent;

    void Start()
    {
        // Get the NavMeshAgent component attached to this GameObject.
        agent = GetComponent<NavMeshAgent>();

        // Check if the NavMeshAgent component exists.
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on this GameObject!");
            enabled = false; // Disable this script if the NavMeshAgent is missing.
            return;
        }

        // Check if a target has been assigned.
        if (target == null)
        {
            Debug.LogError("Target not assigned to AI!");
            enabled = false; // Disable this script if the target is missing.
            return;
        }

        // Set the stopping distance for the agent.
        agent.stoppingDistance = stoppingDistance;
    }

    void Update()
    {
        // Check if the agent is valid and the target is still valid.
        if (agent != null && target != null)
        {
            // Tell the agent to move towards the target's position.
            agent.SetDestination(target.position);
        }
    }
}

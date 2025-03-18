// This script controls the basic AI behavior of a GameObject, allowing it to move towards a target and return to its original position.
// It uses Unity's NavMeshAgent for navigation and changes the object's color to indicate when the target or original position is reached.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform target; // The target the AI will move towards. Drag and drop the target object in the Inspector.
    public float stoppingDistance = 1.0f; // How close the AI should get to the target before stopping.
    public Color targetReachedColor = Color.green; // Color when the target is reached.
    public Color originalColor = Color.white; // Color when returning to the original position.

    private NavMeshAgent agent;
    private Vector3 originalPosition;
    private Renderer objectRenderer;
     private bool isReturning = false;

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

         originalPosition = transform.position;

        // Get the Renderer component to change the color.
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer component not found on this GameObject. Color change will not work.");
        }
        else
        {
            objectRenderer.material.color = originalColor;
        }
    }
 void Update()
    {
        // Check if the agent is valid and the target is still valid.
        if (agent != null && target != null)
        {
            // If not returning, move towards the target.
            if (!isReturning)
            {
                agent.SetDestination(target.position);

                // Check if the target has been reached.
                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                {
                    TargetReached();
                }
            }
            else
            {
                // If returning, move towards the original position.
                agent.SetDestination(originalPosition);

                // Check if the original position has been reached.
                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                {
                    OriginalPositionReached();
                }
            }
        }
    }
     private void TargetReached()
    {
        Debug.Log("Target Reached!");
        // Change color to targetReachedColor.
        if (objectRenderer != null)
        {
            objectRenderer.material.color = targetReachedColor;
        }
        // Start returning to the original position.
        isReturning = true;
    }

    private void OriginalPositionReached()
    {
        Debug.Log("Original Position Reached!");
        // Change color back to originalColor.
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
        // Stop returning.
        isReturning = false;
    }

    public void RestartComportament()
    {
        isReturning = false;
        objectRenderer.material.color = originalColor;
        agent.SetDestination(target.position);
    }
}

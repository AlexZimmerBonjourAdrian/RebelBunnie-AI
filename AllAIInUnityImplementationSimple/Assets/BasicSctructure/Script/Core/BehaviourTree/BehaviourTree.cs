using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    //    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //This is the main class for the behaviour tree.
    //It will contain the root node of the tree.
    //The tree will be traversed from the root node to the leaf nodes.
    //Each node will return a status: success, failure or running.
    //The tree will be traversed until a node returns running or failure.
    //If a node returns success, the tree will continue to the next node.
    //If a node returns failure, the tree will stop.
    //If a node returns running, the tree will continue to the next frame.

}

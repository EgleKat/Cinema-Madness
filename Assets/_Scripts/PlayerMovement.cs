using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Pathfinding.AIPath playerAIScript;
    ManageActionQueue playerQueue;

    private bool finishedTask;
	// Use this for initialization
	void Awake () {
        playerAIScript = GetComponent<Pathfinding.AIPath>();
        playerQueue = GetComponent<ManageActionQueue>();
        finishedTask = true;
    }

    // Update is called once per frame
    void Update () {
		if(!playerQueue.IsTargetsEmpty() && finishedTask)
        {
            finishedTask = false;
            SetPlayerTarget();
            StartMoving();
        }
	}

    /// <summary>
    /// Set next object to travel to
    /// </summary>
    /// <param name="target">The object to travel to</param>
    private void SetPlayerTarget()
    {
        Debug.Log("Target Set");
        GetComponent<Pathfinding.AIDestinationSetter>().target = playerQueue.GetNextTarget().gameObject.transform;
    }

    /// <summary>
    /// Call this after <see cref="SetPlayerTarget"/> to start player moving to destination
    /// </summary>
    private void StartMoving()
    {
        Debug.Log("Moving");
        playerAIScript.canMove = true;
    }

    /// <summary>
    /// Called when touching object to stop player until they have finished interacting with object
    /// </summary>
    private void StopMoving()
    {
        playerAIScript.canMove = false;
    }

    /// <summary>
    /// When first object is clicked start player movement
    /// </summary>
    public void SetFinishedTaskTrue()
    {
        finishedTask = true;
    }
}

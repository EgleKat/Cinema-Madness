using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour {

    Pathfinding.AIPath aiScript;
    SuperActionQueue manageQueue;

    private bool finishedTask;

	// Use this for initialization
	void Awake () {
        aiScript = GetComponent<Pathfinding.AIPath>();

        if (gameObject.name == "Player")
        {
            manageQueue = GetComponent<SuperActionQueue>();
        }

        finishedTask = true;
    }

    // Update is called once per frame
    void Update () {
		if(!manageQueue.IsQueueEmpty() && finishedTask)
        {
            finishedTask = false;
            SetTarget();
            StartMoving();
        }
        else
        {
            StopMoving();
        }
	}

    /// <summary>
    /// Set next object to travel to
    /// </summary>
    /// <param name="target">The object to travel to</param>
    private ServiceStation SetTarget()
    {
        ServiceStation nextTarget = manageQueue.GetNextTarget();
        GetComponent<Pathfinding.AIDestinationSetter>().target = nextTarget.gameObject.transform;
        return nextTarget;
    }

    /// <summary>
    /// Call this after <see cref="SetPlayerTarget"/> to start player moving to destination
    /// </summary>
    private void StartMoving()
    {
        aiScript.canMove = true;
    }

    /// <summary>
    /// Called when touching object to stop player until they have finished interacting with object
    /// </summary>
    private void StopMoving()
    {
        aiScript.canMove = false;
    }

    /// <summary>
    /// When first object is clicked start player movement
    /// </summary>
    public void SetFinishedTaskTrue()
    {
        finishedTask = true;
    }
}

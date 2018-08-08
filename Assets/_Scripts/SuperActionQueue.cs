using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperActionQueue : MonoBehaviour {

    // Stores the objects the player will travel to
    protected Queue<ServiceStation> actionQueue;
    // Keeps track of current queue size
    protected int sizeCounter;
    protected ServiceStation currentTarget;
    protected bool isManageNPCQueue;
    protected ServiceStation lastTarget;
    protected void OnAwake()
    {
        actionQueue = new Queue<ServiceStation>();
        sizeCounter = 0;
        isManageNPCQueue = false;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public bool IsQueueEmpty()
    {
        return actionQueue.Count > 0 ? false : true;
    }

    /// <summary>
    /// Gets the object the player will tarvel to next
    /// </summary>
    /// <returns>The next object in the <see cref="targets"/> queue</returns>
    public ServiceStation GetNextTarget()
    {
        sizeCounter--;
        lastTarget = actionQueue.Dequeue();
        Debug.Log("Removed " + lastTarget);
        return lastTarget;
    }

    public bool GetIsManageNPCQueue()
    {
        return isManageNPCQueue;
    }
}

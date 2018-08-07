using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperActionQueue : MonoBehaviour {

    // Stores the objects the player will travel to
    protected Queue<ServiceStation> actionQueue;
    // Keeps track of current queue size
    protected int sizeCounter;
    protected ServiceStation currentTarget;

    void Awake()
    {
        actionQueue = new Queue<ServiceStation>();
        sizeCounter = 0;
    }
    // Use this for initialization
    void Start () {
		
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
        Debug.Log("Dequeue next service station, count = " + actionQueue.Count);
        sizeCounter--;
        return actionQueue.Dequeue();
    }

}

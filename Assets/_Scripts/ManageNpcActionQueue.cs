using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNpcActionQueue : SuperActionQueue {
   
    ServiceStation toilet;
    ServiceStation popcorn;
    Movement movement;

    private void Awake()
    {
        toilet = GameObject.FindGameObjectWithTag("Bathroom").GetComponent<ServiceStation>();
        popcorn = GameObject.FindGameObjectWithTag("PopcornMachine").GetComponent<ServiceStation>();
        movement = GetComponent<Movement>();
        OnAwake();
    }

    // Use this for initialization
    void Start () {
        isManageNPCQueue = true;
        actionQueue.Enqueue(toilet);
        actionQueue.Enqueue(popcorn);
        actionQueue.Enqueue(toilet);

        CheckQueue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishTask()
    {
        CheckQueue();
    }

    private void CheckQueue()
    {
        if (!IsQueueEmpty())
        {
            movement.SetTarget();
        }
        else
        {
            //TODO move this to movement
            GetComponent<Pathfinding.AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Spawn").transform;
        }
        movement.StartMoving();

    }
}

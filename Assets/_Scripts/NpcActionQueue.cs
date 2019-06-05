using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcActionQueue : ActionQueue {
   
    ServiceStation toilet;
    ServiceStation popcorn;
    Movement movement;
    private void Awake()
    {
        toilet = GameObject.FindGameObjectWithTag("Bathroom").GetComponent<ServiceStation>();
        popcorn = GameObject.FindGameObjectWithTag("PopcornStall").GetComponent<ServiceStation>();
        movement = gameObject.GetComponent<Movement>();
        OnAwake();
    }

    // Use this for initialization
    void Start () {
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
            movement.SetTarget(GetNextTarget().gameObject);
            movement.StartMoving();
        }
        else
        {
            movement.SetTarget(GameObject.FindGameObjectWithTag("Spawn"));
            movement.StartMoving();
        }

    }
}

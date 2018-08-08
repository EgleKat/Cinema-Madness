using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNpcActionQueue : SuperActionQueue {
   
    ServiceStation toilet;
    Movement movement;

    private void Awake()
    {
        toilet = GameObject.FindGameObjectWithTag("Bathroom").GetComponent<ServiceStation>();
        movement = GetComponent<Movement>();
        OnAwake();
    }

    // Use this for initialization
    void Start () {
        isManageNPCQueue = true;
        actionQueue.Enqueue(toilet);
        CheckQueue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishTask()
    {
       // Debug.Log("Moving on to next task");
        CheckQueue();
    }

    private void CheckQueue()
    {
        if (!IsQueueEmpty())
        {
           // Debug.Log("Entering queue");
            movement.SetTarget().EnterQueue(this);
            movement.StartMoving();

        }
        else
        {
            //Go home
            //Debug.Log("Going home");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNpcActionQueue : SuperActionQueue {
   
    ToiletLogic toilet;


    private void Awake()
    {
        toilet = GameObject.FindGameObjectWithTag("Bathroom").GetComponent<ToiletLogic>();
    }
    // Use this for initialization
    void Start () {
        
        actionQueue.Enqueue(toilet);
        CheckQueue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishTask()
    {
        Debug.Log("Moving on to next task");
        CheckQueue();
    }

    private void CheckQueue()
    {
        if (IsQueueEmpty())
        {
            Debug.Log("Entering queue");
            actionQueue.Dequeue().EnterQueue(this);

        }
        else
        {
            //Go home
            Debug.Log("Going home");
        }
    }
}

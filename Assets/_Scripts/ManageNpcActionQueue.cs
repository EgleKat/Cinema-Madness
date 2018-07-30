using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNpcActionQueue : MonoBehaviour {
   
    Queue<ToiletLogic> actionQueue;
    ToiletLogic toilet;


    private void Awake()
    {
        toilet = GameObject.FindGameObjectWithTag("Bathroom").GetComponent<ToiletLogic>();
        actionQueue = new Queue<ToiletLogic>();
    }
    // Use this for initialization
    void Start () {
        
        actionQueue.Enqueue(toilet);
        enterQueue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void finishTask()
    {
        Debug.Log("Moving on to next task");
        enterQueue();
    }

    private void enterQueue()
    {
        if (actionQueue.Count != 0)
        {
            Debug.Log("Entering queue");
            actionQueue.Dequeue().enterQueue(this);

        }
        else
        {
            //Go home
            Debug.Log("Going home");
        }
    }
}

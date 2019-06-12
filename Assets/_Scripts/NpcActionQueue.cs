using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcActionQueue :MonoBehaviour {
   
    ServiceStation toilet;
    ServiceStation popcorn;
    Movement movement;
    private Queue<ServiceStation> actionQueue;
    private ServiceStation exit;

    private void Awake()
    {
        //TODO populate from NPCSpawner
        toilet = GameObject.FindGameObjectWithTag("Bathroom").GetComponent<ServiceStation>();
        popcorn = GameObject.FindGameObjectWithTag("PopcornStall").GetComponent<ServiceStation>();
        exit = GameObject.FindGameObjectWithTag("Exit").GetComponent<ServiceStation>();
        movement = gameObject.GetComponent<Movement>();
        actionQueue = new Queue<ServiceStation>();
    }

    // Use this for initialization
    void Start () {
        actionQueue.Enqueue(toilet);
        //actionQueue.Enqueue(toilet);
        actionQueue.Enqueue(popcorn);

        actionQueue.Enqueue(exit);
        SetNextTarget();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishTask()
    {
        SetNextTarget();
    }

    private void SetNextTarget()
    {
        movement.SetTarget(actionQueue.Dequeue().gameObject);
        movement.StartMoving();
    }
}

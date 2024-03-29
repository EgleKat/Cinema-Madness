﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcActionQueue : MonoBehaviour
{

    ServiceStation toilet;
    ServiceStation popcorn;
    Movement movement;
    private Queue<ServiceStation> actionQueue;
    
    public ServiceStation nextTarget;
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
    void Start()
    {
        actionQueue.Enqueue(toilet);
        //actionQueue.Enqueue(toilet);
        actionQueue.Enqueue(popcorn);

        actionQueue.Enqueue(exit);
        SetNextTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FinishTask()
    {
        SetNextTarget();
    }

    private void SetNextTarget()
    {
        if (actionQueue.Count != 0)
        {
            nextTarget = actionQueue.Dequeue();
            movement.SetTarget(nextTarget.gameObject);
        }
        movement.StartMoving();
    }


    //so that NPCs queue behind each other
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            if (nextTarget.waitingNpcs.Contains(collision.gameObject.GetComponent<NpcActionQueue>())) {
                // if NPC we collided with is already waiting at the service station we want to go to
                nextTarget.EnterQueue(this);
                movement.StopMoving();
            }
            
        }
    }
}

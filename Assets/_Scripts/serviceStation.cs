using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Superclass for objects which NPCs can use. It has general queue and lockdown methods
/// </summary>
public class ServiceStation : MonoBehaviour
{

    bool locked;
    ManageActionQueue playerActionQueue;
    Queue<ManageNpcActionQueue> waitingNpcs;

    private void Awake()
    {
        playerActionQueue = GameObject.FindGameObjectWithTag("Player").GetComponent<ManageActionQueue>();
        waitingNpcs = new Queue<ManageNpcActionQueue>();
        unlockObject();
    }
    private void unlockObject()
    {
        locked = false;
    }

    private void lockObject()
    {
        locked = true;
    }
    private void OnMouseDown()
    {
        playerActionQueue.addToQueue(this);
    }

    public void enterQueue(ManageNpcActionQueue npcActionQueue)
    {
        waitingNpcs.Enqueue(npcActionQueue);
        acceptNpc();
    }

    private void acceptNpc()
    {
        //Start timer
        //When timer's finished, pop the person of the queue
        Debug.Log("Serving NPC");
        serveFirstNpc();
        lockObject();
    }
    private void serveFirstNpc()
    {
        Debug.Log("Dequeing npc");
        waitingNpcs.Dequeue().finishTask();
    }

}

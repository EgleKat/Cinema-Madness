using System;
using UnityEngine;
using System.Collections.Generic;

public class ServiceStation : MonoBehaviour
{

    bool inUse;
    ManageActionQueue playerActionQueue;
    Queue<ManageNpcActionQueue> waitingNpcs;

    private void Awake()
    {
        playerActionQueue = GameObject.FindGameObjectWithTag("Player").GetComponent<ManageActionQueue>();
        waitingNpcs = new Queue<ManageNpcActionQueue>();
        inUse = false;
    }
    private void unlockObject()
    {
        inUse = false;
    }

    private void lockObject()
    {
        inUse = true;
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
    }
    private void serveFirstNpc()
    {
        Debug.Log("Dequeing npc");
        waitingNpcs.Dequeue().finishTask();
    }

}

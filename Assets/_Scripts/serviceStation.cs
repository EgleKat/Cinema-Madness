using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Superclass for objects which NPCs can use. It has general queue and lockdown methods
/// </summary>
public class ServiceStation : MonoBehaviour
{

    protected bool locked;
    protected ManageActionQueue playerActionQueue;
    public Queue<ManageNpcActionQueue> waitingNpcs;

    protected void Awake()
    {
        playerActionQueue = GameObject.FindGameObjectWithTag("Player").GetComponent<ManageActionQueue>();
        waitingNpcs = new Queue<ManageNpcActionQueue>();
        unlockObject();
    }
    protected void unlockObject()
    {
        locked = false;
    }

    protected void lockObject()
    {
        locked = true;
    }
    protected void OnMouseDown()
    {
        playerActionQueue.addToQueue(this);
    }

    public virtual void enterQueue(ManageNpcActionQueue npcActionQueue)
    {
        waitingNpcs.Enqueue(npcActionQueue);
        acceptNpc();
    }

    protected virtual void acceptNpc()
    {
        if (!locked)
        {
            //Pop the NPC of the queue
            Debug.Log("Serving NPC");
            serveFirstNpc();
            lockObject();
        }
    }
    protected virtual void serveFirstNpc()
    {
        Debug.Log("Dequeing npc base");
        waitingNpcs.Dequeue().finishTask();
        lockObject();
    }
    /// <summary>
    /// Called when the player reaches the service
    /// </summary>
    public virtual void ActivateService()
    {

    }

}

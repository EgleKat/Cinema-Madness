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
    protected float timeToServeNpc = 0;
    public Queue<ManageNpcActionQueue> waitingNpcs;
    private GameObject timer;

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
        if (!locked && waitingNpcs.Count !=0)
        {
            //Pop the NPC of the queue
            Debug.Log("Serving NPC");
            serveFirstNpc();
            lockObject();
        }
    }
    protected void serveFirstNpc()
    {
        if (!locked)
        {
            Invoke("finishServingNpc", timeToServeNpc);
            timer = Instantiate(Resources.Load("Prefabs/TimerCircle") as GameObject, gameObject.transform);
            timer.GetComponent<Animator>().speed = 1 / timeToServeNpc;
            Debug.Log("Dequeing npc");
        }
    }
    protected void finishServingNpc()
    {
        unlockObject();
        waitingNpcs.Dequeue().finishTask();
        Debug.Log("Toilet Locked. Clean it!");

        //remove timer
        Destroy(timer);

    }
    /// <summary>
    /// Called when the player reaches the service
    /// </summary>
    public virtual void ActivateService()
    {

    }

}

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
        UnlockObject();
    }
    protected void UnlockObject()
    {
        locked = false;
    }

    protected void LockObject()
    {
        locked = true;
    }
    protected void OnMouseDown()
    {
        playerActionQueue.AddToQueue(this);
    }
    /// <summary>
    /// Push npc into the queue
    /// </summary>
    /// <param name="npcActionQueue"></param>
    public virtual void EnterQueue(ManageNpcActionQueue npcActionQueue)
    {
        waitingNpcs.Enqueue(npcActionQueue);
        AcceptNpc();
    }
    /// <summary>
    /// Let npc use the queue if the service isn't locked
    /// </summary>
    protected virtual void AcceptNpc()
    {
        if (!locked && waitingNpcs.Count !=0)
        {
            //Pop the NPC of the queue
            Invoke("FinishServingNpc", timeToServeNpc);
            timer = Instantiate(Resources.Load("Prefabs/TimerCircle") as GameObject, gameObject.transform);
            timer.GetComponent<Animator>().speed = 1 / timeToServeNpc;
            LockObject();
        }
    }
    /// <summary>
    /// Called after the timer runs out
    /// </summary>
    protected void FinishServingNpc()
    {
        UnlockObject();
        waitingNpcs.Dequeue().FinishTask();
        Debug.Log("Toilet Locked. Clean it!");

        //remove timer
        Destroy(timer);

    }
    /// <summary>
    /// Called when the player (main character) reaches the service
    /// </summary>
    public virtual void ActivateService( )
    {

    }

}

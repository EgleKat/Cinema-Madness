using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Superclass for objects which NPCs can use. It has general queue and lockdown methods
/// </summary>
public class ServiceStation : MonoBehaviour
{

    protected bool locked;
    protected PlayerActionQueue playerActionQueue;
    protected float timeToServeNpc = 0;
    public Queue<NpcActionQueue> waitingNpcs;
    protected GameObject timer;
    protected StationTrigger trigger;

    protected void Awake()
    {
        playerActionQueue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActionQueue>();
        waitingNpcs = new Queue<NpcActionQueue>();
        trigger = GetComponent<StationTrigger>();

        UnlockStation();
    }
    protected void UnlockStation()
    {
        locked = false;
    }

    protected void LockStation()
    {
        locked = true;
    }

    protected void OnMouseUp()
    {
        playerActionQueue.AddToQueue(this);
    }

    protected bool IsStationLocked() 
    {
        return locked;
    }
    /// <summary>
    /// Push npc into the queue
    /// </summary>
    /// <param name="npcActionQueue"></param>
    public virtual void EnterQueue(NpcActionQueue npcActionQueue)
    {
        waitingNpcs.Enqueue(npcActionQueue);
        AcceptNpc();
    }
    /// <summary>
    /// Let npc use the queue if the service isn't locked
    /// </summary>
    public virtual void AcceptNpc()
    {
        if (!locked && waitingNpcs.Count != 0 )
        {
            LockStation();
            //Pop the NPC off the queue
            Invoke("FinishServingNpc", timeToServeNpc);
            timer = Instantiate(Resources.Load("Prefabs/TimerCircle") as GameObject, gameObject.transform);
            timer.GetComponent<Animator>().speed = 1 / timeToServeNpc;
            
        }
    }

    /// <summary>
    /// Called after the timer runs out
    /// </summary>
    protected virtual void FinishServingNpc()
    {
        UnlockStation();
        waitingNpcs.Dequeue().FinishTask();
        //remove timer
        Destroy(timer);

    }

    /// <summary>
    /// Called when the player (main character) reaches the service
    /// </summary>
    public virtual void ActivateService()
    {
        //call player here

        playerActionQueue.FinishWithServiceStation();
        AcceptNpc();
    }

}

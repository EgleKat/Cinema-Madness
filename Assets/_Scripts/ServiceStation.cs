﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
    public void EnterQueue(NpcActionQueue npcActionQueue)
    {
        if (!waitingNpcs.Contains(npcActionQueue))
        {
            waitingNpcs.Enqueue(npcActionQueue);
            AcceptNpc();
        }
    }

    public virtual void AcceptNpc()
    {
        AcceptNpcExtras();
    }

    /// <summary>
    /// Let npc use the queue if the service isn't locked
    /// </summary>
    public virtual void AcceptNpcExtras()
    {
        if (!locked && waitingNpcs.Count != 0)
        {
            LockStation();
            //Pop the NPC off the queue
            Invoke("FinishServingNpc", timeToServeNpc);
            timer = Instantiate(Resources.Load("Prefabs/TimerCircle") as GameObject, gameObject.transform);
            timer.GetComponent<Animator>().speed = 1 / timeToServeNpc;
            timer.transform.localScale = new Vector3(0.5f, 0.5f, timer.transform.localScale.z);


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
        MoveQueueUp();
    }

    protected async void MoveQueueUp()
    {
        for (int i = 0; i < waitingNpcs.Count; i++)
        {
            var waitingNpc = waitingNpcs.ElementAtOrDefault(i);
            if (waitingNpc == null) { continue; }
            Movement nextNpcMovement = waitingNpc.GetComponent<Movement>();
            if (!nextNpcMovement.isAtFrontOfQueue)
            {
                nextNpcMovement.StartMoving();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
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

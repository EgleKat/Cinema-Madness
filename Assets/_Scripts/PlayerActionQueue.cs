using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerActionQueue : MonoBehaviour
{

    // Largest size queue can grow to
    public readonly int MAXSIZE = 3;
    private bool firstObjectAdded;
    private Movement playerMovement;
    private Queue<ServiceStation> actionQueue;

    PlayerState currentState;
    private ServiceStation nextTarget;

    PlayerActionQueueText playerActionQueueText;
    void Awake()
    {
        playerActionQueueText = GameObject.FindGameObjectWithTag("PlayerActionQueueText").GetComponent<PlayerActionQueueText>();
        actionQueue = new Queue<ServiceStation>();
        //firstObjectAdded = false;
        playerMovement = GetComponent<Movement>();
        currentState = PlayerState.Idle;
    }


    /// <summary>
    /// Adds a new object to the <see cref="targets"/> queue if it is not full
    /// </summary>
    /// <param name="newTarget">The object being added</param>
    /// <returns>Shows if the add was successful</returns>
    public bool AddToQueue(ServiceStation serviceStation)
    {
        if (actionQueue.Count < MAXSIZE)
        {

            actionQueue.Enqueue(serviceStation);
            playerActionQueueText.SetText(nextTarget, actionQueue);

            if (currentState != PlayerState.Moving)
            {
                SetNextTarget();
            }
            return true;
        }
        return false;
    }

    private void SetNextTarget()
    {
        if (actionQueue.Count != 0)
        {
            nextTarget = actionQueue.Dequeue();
            playerActionQueueText.SetText(nextTarget, actionQueue);

            String targetTag = nextTarget.gameObject.tag;
            PlayerState targetState = GetNextState(targetTag);

            if (targetState != currentState)
            {
                playerMovement.SetTarget(nextTarget.gameObject);
                currentState = PlayerState.Moving;
                playerMovement.StartMoving();
            }
            //it's the same service station where the player is standing
            else
            {
                //activate the service without walking
                nextTarget.gameObject.GetComponent<ServiceStation>().ActivateService();
            }

        }
        else
        {
            nextTarget = null;
        }
    }

    public ServiceStation GetNextTarget()
    {
        return nextTarget;
    }

    public PlayerState GetNextState(String targetTag)
    {
        switch (targetTag)
        {
            case "PopcornMachine":
                return PlayerState.PopcornMachine;
            case "Bathrooms":
                return PlayerState.Bathrooms;
            case "PopcornStall":
                return PlayerState.PopcornStall;
            default:
                return PlayerState.Idle;
        }

    }

    public void SetState(String stateTag)
    {
        currentState = GetNextState(stateTag);
    }

    public void FinishWithServiceStation()
    {
        SetNextTarget();
    }

    public PlayerState GetCurrentState()
    {
        return currentState;
    }



}
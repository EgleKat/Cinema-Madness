using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerActionQueue : ActionQueue
{

    // Largest size queue can grow to
    public readonly int MAXSIZE = 10;
    private bool firstObjectAdded;
    private Movement playerMovement;
    // Use this for initialization

    PlayerState currentState;
    void Awake()
    {
        OnAwake();
        firstObjectAdded = false;
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
             
            if (IsQueueEmpty() && (!firstObjectAdded))
            {
                firstObjectAdded = true;
                actionQueue.Enqueue(serviceStation);
                SetNextTarget();
            }
            else
            {
                actionQueue.Enqueue(serviceStation);
                SetNextTarget();
            }
            
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetNextTarget()
    {
        if (!IsQueueEmpty())
        {
            GetNextTarget();
            String targetTag = GetLastTarget().gameObject.tag;
            Debug.Log("Target tag " + targetTag);

            PlayerState targetState = GetNextState(targetTag);
            Debug.Log("Next state will be " + targetState);

            if(targetState != currentState)
            {
                playerMovement.SetTarget(GetLastTarget().gameObject);
                 currentState = PlayerState.Moving;
                playerMovement.StartMoving();
                Debug.Log("Walking");

            }
            //it's the same service station where the player is standing
            else{
                //activate the service without walking
                GetLastTarget().gameObject.GetComponent<ServiceStation>().ActivateService();
            }

        }
        else
        {
            //Do nothing
        }
    }

    public PlayerState GetNextState(String targetTag)
    {
        switch(targetTag)
        {
            case "PopcornMachine":
                return PlayerState.PopcornMachine;
            case "Bathrooms":
                return PlayerState.Bathrooms;
            case "PopcornStall":
                return PlayerState.PopcornStall;
            default:
                return PlayerState.Idle ;
        }       

    }

    public void SetState(String stateTag) {
        currentState = GetNextState(stateTag);
    }

    public void FinishWithServiceStation()
    {
        SetNextTarget();
    }

    public PlayerState GetCurrentState() {
        return currentState;
    }
}
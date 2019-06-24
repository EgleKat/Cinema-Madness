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
    Animator playerAnimator;
    private ServiceStation nextTarget;

    PlayerActionQueueText playerActionQueueText;
    void Awake()
    {
        playerActionQueueText = GameObject.FindGameObjectWithTag("PlayerActionQueueText").GetComponent<PlayerActionQueueText>();
        actionQueue = new Queue<ServiceStation>();
        playerMovement = GetComponent<Movement>();
        currentState = PlayerState.Idle;
        playerAnimator = gameObject.GetComponent<Animator>();
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

            String targetTag = nextTarget.gameObject.tag;
            PlayerState targetState = GetNextState(targetTag);

            if (targetState != currentState)
            {
                playerMovement.SetTarget(nextTarget.gameObject);
                SetState(PlayerState.Moving);
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
        playerActionQueueText.SetText(nextTarget, actionQueue);

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
            case "Bathroom":
                return PlayerState.Bathroom;
            case "PopcornStall":
                return PlayerState.PopcornStall;
            default:
                return PlayerState.Idle;
        }

    }

    public void SetStateWithString(String stateTag)
    {
        SetState(GetNextState(stateTag));
    }
    public void SetState(PlayerState state)
    {
        currentState = state;
        if (currentState == PlayerState.Moving)
        {
            playerAnimator.SetBool("isMoving", true);
            
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
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
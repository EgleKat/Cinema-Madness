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
    void Awake()
    {
        OnAwake();
        firstObjectAdded = false;
        playerMovement = GetComponent<Movement>();
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
                playerMovement.StartMoving();
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
            playerMovement.SetTarget(GetNextTarget().gameObject);
            playerMovement.StartMoving();
        }
        else
        {
            //Do nothing
        }
    }

    public void FinishWithServiceStation()
    {
        SetNextTarget();
        playerMovement.StartMoving();

    }
}
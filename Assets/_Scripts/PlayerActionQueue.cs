using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerActionQueue : ActionQueue
{

    // Largest size queue can grow to
    public readonly int MAXSIZE = 10;
    private Movement playerMovement;
    private Pathfinding.AIPath playerAI;
    private bool firstObjectAdded;

    // Use this for initialization
    void Awake()
    {
        OnAwake();
        playerAI = GameObject.FindGameObjectWithTag("Player").GetComponent<Pathfinding.AIPath>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        firstObjectAdded = false;
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
            if (IsQueueEmpty() && (playerAI.reachedEndOfPath || !firstObjectAdded))
            {
                firstObjectAdded = true;
                actionQueue.Enqueue(serviceStation);

                playerMovement.SetTarget(GetNextTarget());
            }
            else
            {
                actionQueue.Enqueue(serviceStation);
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
            playerMovement.SetTarget(GetNextTarget());
        }
        else
        {
            ResetLastTarget();
        }
    }

    public void FinishWithServiceStation()
    {
        SetNextTarget();
    }
}
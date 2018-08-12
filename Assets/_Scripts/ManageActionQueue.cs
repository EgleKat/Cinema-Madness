using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ManageActionQueue : SuperActionQueue
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
        if (sizeCounter < MAXSIZE)
        {
            if (IsQueueEmpty() && (playerAI.reachedEndOfPath || !firstObjectAdded))
            {
                firstObjectAdded = true;
                Debug.Log("Added " + serviceStation + "to queue");
                actionQueue.Enqueue(serviceStation);
                sizeCounter++;

                playerMovement.SetTargetFromQueue();
                playerMovement.StartMoving();
            }
            else
            {
                Debug.Log("Added " + serviceStation + "to queue");
                actionQueue.Enqueue(serviceStation);
                sizeCounter++;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
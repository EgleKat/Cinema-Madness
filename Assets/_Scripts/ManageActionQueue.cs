using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ManageActionQueue : SuperActionQueue
{

    // Largest size queue can grow to
    public int MAXSIZE = 10;

    // Use this for initialization
    void Awake()
    {

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
            Debug.Log("Adding Action to queue");
            actionQueue.Enqueue(serviceStation);
            sizeCounter++;
            serviceStation.ActivateService();
            return true;
        }
        else
        {
            return false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageActionQueue : MonoBehaviour
{

    /// Stores the objects the player will travel to
    Queue<ServiceStation> targets;

    // Keeps track of current queue size
    int sizeCounter;

    // Largest size queue can grow to
    public int MAXSIZE = 10;

    // Use this for initialization
    void Start()
    {
        targets = new Queue<ServiceStation>();
        sizeCounter = 0;
    }


    /// <summary>
    /// Gets the object the player will tarvel to next
    /// </summary>
    /// <returns>The next object in the <see cref="targets"/> queue</returns>
    public ServiceStation GetNextTarget()
    {
        sizeCounter--;
        return targets.Count == 0 ? null : targets.Dequeue();
    }

    /// <summary>
    /// Adds a new object to the <see cref="targets"/> queue if it is not full
    /// </summary>
    /// <param name="newTarget">The object being added</param>
    /// <returns>Shows if the add was successful</returns>
    public bool AddToQueue(ServiceStation serviceStation)
    {
        Debug.Log("Adding Action to queue");

        if (sizeCounter < MAXSIZE)
        {
            targets.Enqueue(serviceStation);
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
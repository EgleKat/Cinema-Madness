using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the targets that the player will move to
/// </summary>
public class TargetChanging : MonoBehaviour {
    
    /// Stores the objects the player will travel to
    Queue<GameObject> targets;

    // Keeps track of current queue size
    int sizeCounter;

    // Largest size queue can grow to
    public int MAXSIZE = 10;

	// Use this for initialization
	void Start () {
        targets = new Queue<GameObject>();
        sizeCounter = 0;
	}
	
    /// <summary>
    /// Adds a new object to the <see cref="targets"/> queue if it is not full
    /// </summary>
    /// <param name="newTarget">The object being added</param>
    /// <returns>Shows if the add was successful</returns>
    public bool AddTarget(GameObject newTarget)
    {
        if (sizeCounter < MAXSIZE)
        {
            targets.Enqueue(newTarget);
            sizeCounter++;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the object the player will tarvel to next
    /// </summary>
    /// <returns>The next object in the <see cref="targets"/> queue</returns>
    public GameObject GetNextTarget()
    {
        sizeCounter--;
        return targets.Count == 0 ? null : targets.Dequeue();
    }

	// Update is called once per frame
	void Update () {
		
	}
}

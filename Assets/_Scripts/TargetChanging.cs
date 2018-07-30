using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the targets that the player will move to
/// </summary>
public class TargetChanging : MonoBehaviour {
    
    /// <summary>
    /// Stores the objects the player will travel to
    /// </summary>
    Queue<GameObject> targets;

	// Use this for initialization
	void Start () {
        targets = new Queue<GameObject>();
	}
	
    /// <summary>
    /// Adds a new object to the <see cref="targets"/> queue
    /// </summary>
    /// <param name="newTarget">The object being added</param>
    public void AddTarget(GameObject newTarget)
    {
        targets.Enqueue(newTarget);
    }

    /// <summary>
    /// Gets the object the player will tarvel to next
    /// </summary>
    /// <returns>The next object in the <see cref="targets"/> queue</returns>
    public GameObject GetNextTarget()
    {
        return targets.Count == 0 ? null : targets.Dequeue();
    }

	// Update is called once per frame
	void Update () {
		
	}
}

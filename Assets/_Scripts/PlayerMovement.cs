using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Pathfinding.AIPath playerAIScript;
    ManageActionQueue playerQueue;
	// Use this for initialization
	void Awake () {
        playerAIScript = GetComponent<Pathfinding.AIPath>();
        playerQueue = GetComponent<ManageActionQueue>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Set next object to travel to
    /// </summary>
    /// <param name="target">The object to travel to</param>
    public void SetPlayerTarget()
    {
        GetComponent<Pathfinding.AIDestinationSetter>().target = playerQueue.GetNextTarget().gameObject.transform;
    }

    public void StartMoving()
    {
        playerAIScript.canMove = true;
    }

    public void StopMoving()
    {
        playerAIScript.canMove = false;
    }

}

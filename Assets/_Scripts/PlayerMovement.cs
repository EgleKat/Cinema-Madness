using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Pathfinding.AIPath playerAIScript;
	// Use this for initialization
	void Awake () {
        playerAIScript = gameObject.GetComponent<Pathfinding.AIPath>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Set next object to travel to
    /// </summary>
    /// <param name="target">The object to travel to</param>
    public void SetPlayerTarget(ServiceStation target)
    {
        gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = target.gameObject.transform;
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

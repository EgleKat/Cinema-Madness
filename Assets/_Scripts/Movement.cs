using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour {

    Pathfinding.AIDestinationSetter aiDestinationSetter;
    //Pathfinding.AIPath aiPath;

	// Use this for initialization
	void Awake () {
        aiDestinationSetter = GetComponent<Pathfinding.AIDestinationSetter>();
    }

    /// <summary>
    /// Set target to object passed in
    /// </summary>
    /// <param name="target">Target to travel to</param>
    public void SetTarget(GameObject target)
    {
        aiDestinationSetter.target = target.transform;
    }

    public void SetTarget(ServiceStation target)
    {
        aiDestinationSetter.target = target.gameObject.transform;
    }

    ///// <summary>
    ///// Call this after <see cref="SetPlayerTarget"/> to start player moving to destination
    ///// </summary>
    //public void StartMoving()
    //{
    //    aiPath.canMove = true;
    //}

    ///// <summary>
    ///// Called when touching object to stop player until they have finished interacting with object
    ///// </summary>
    //private void StopMoving()
    //{
    //    aiPath.canMove = false;
    //}
}

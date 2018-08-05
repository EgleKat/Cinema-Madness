using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTrigger : MonoBehaviour {

    PlayerMovement movePlayer;
    ManageActionQueue playerQueue;
    Pathfinding.AIPath triggerPlayerMovement;
	// Use this for initialization
	void Awake () {
        GameObject player = GameObject.Find("Player");
        playerQueue = player.GetComponent<ManageActionQueue>();
        movePlayer = player.GetComponent<PlayerMovement>();
        triggerPlayerMovement = player.GetComponent<Pathfinding.AIPath>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerPlayerMovement.canMove = false;
    }

    private void OnMouseDown()
    {
        playerQueue.AddToQueue(gameObject.GetComponent<ServiceStation>());
    }
}

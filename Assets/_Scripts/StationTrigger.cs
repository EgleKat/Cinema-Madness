using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Defines collider/trigger behaviour for ServiceStation
/// </summary>
public class StationTrigger : MonoBehaviour {

    Movement movePlayer;
    ManageActionQueue playerQueue;
    Pathfinding.AIPath triggerPlayerMovement;
    private bool working;


	// Use this for initialization
	void Awake () {
        GameObject player = GameObject.Find("Player");
        playerQueue = player.GetComponent<ManageActionQueue>();
        movePlayer = player.GetComponent<Movement>();
        triggerPlayerMovement = player.GetComponent<Pathfinding.AIPath>();
        working = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Collide with an objetc
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && !working && playerQueue.GetLastTarget() == GetComponent<ServiceStation>())
        {
            Debug.Log("Service Activated");
            working = true;
            GetComponent<ServiceStation>().ActivateService();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            gameObject.GetComponent<ServiceStation>().EnterQueue(collision.gameObject.GetComponent<ManageNpcActionQueue>());
        }
    }

    public void NotWorking()
    {
        working = false;
    }

}

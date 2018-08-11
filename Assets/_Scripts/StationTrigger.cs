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


	// Use this for initialization
	void Awake () {
        GameObject player = GameObject.Find("Player");
        playerQueue = player.GetComponent<ManageActionQueue>();
        movePlayer = player.GetComponent<Movement>();
        triggerPlayerMovement = player.GetComponent<Pathfinding.AIPath>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Collide with an objetc
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object triggered");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Service Activated");
            GetComponent<ServiceStation>().ActivateService();
        }
        else if (collision.gameObject.CompareTag("NPC"))
        {
            gameObject.GetComponent<ServiceStation>().EnterQueue(collision.gameObject.GetComponent<ManageNpcActionQueue>());
        }
    }

}

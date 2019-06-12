using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Defines collider/trigger behaviour for ServiceStation
/// </summary>
public class StationTrigger : MonoBehaviour {

    PlayerActionQueue playerQueue;

	// Use this for initialization
	void Awake () {
        GameObject player = GameObject.Find("Player");
        playerQueue = player.GetComponent<PlayerActionQueue>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Collide with the player
    /// </summary>
    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     // if the collidee is Player AND if the player is already at the station
    //     if (collision.gameObject.CompareTag("Player") && playerQueue.GetLastTarget() == GetComponent<ServiceStation>())
    //     {
    //         GetComponent<ServiceStation>().ActivateService();
    //         GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().StopMoving();
    //     }
    // }

    
    /// <summary>
    /// Collide with NPC
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            gameObject.GetComponent<ServiceStation>().EnterQueue(collision.gameObject.GetComponent<NpcActionQueue>());
            collision.gameObject.GetComponent<Movement>().StopMoving();
        }

          // if the collidee is Player AND if the player is already at the station
        else if (collision.gameObject.CompareTag("Player") && playerQueue.GetNextTarget() == GetComponent<ServiceStation>())
        {
            GetComponent<ServiceStation>().ActivateService();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Movement>().StopMoving();
            //set the state to be the service station
            player.GetComponent<PlayerActionQueue>().SetState(gameObject.tag);
        }
    }
    

}

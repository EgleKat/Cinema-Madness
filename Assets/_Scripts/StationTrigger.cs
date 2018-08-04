using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTrigger : MonoBehaviour {

    ManageActionQueue playerQueue;
	// Use this for initialization
	void Awake () {
        playerQueue = GameObject.Find("Player").GetComponent<ManageActionQueue>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        
    }
}

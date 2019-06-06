using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Vector3 position;
    //Which direction to move in

    private Vector3 stationPosition;
    private bool move=false;
    private float speed = 0.05f;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Awake()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(move){
            position = gameObject.transform.position;
            //find the direction, where to go and multiply by speed
            velocity = Vector3.Normalize(stationPosition - position) * speed;
            //change position based on velocity
            gameObject.transform.position = position + velocity;
        }
    }

    public void SetTarget(GameObject station) {
        stationPosition = station.transform.position;    
    }

    public void StartMoving() {
        move = true;            
    }

    public void StopMoving() {
        move = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Vector3 position;
    public bool isAtFrontOfQueue;

    //Which direction to move in

    private Vector2 stationPosition;
    private bool move = false;
    private float speed = 0.05f;
    private Vector2 velocity = Vector2.zero;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Awake()
    {
        position = gameObject.transform.position;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            position = gameObject.transform.position;
            Vector2 vector2Position = (Vector2)position;
            //find the direction, where to go and multiply by speed
            velocity = (stationPosition - vector2Position).normalized * speed;

            Vector3 newVector3Position = vector2Position + velocity;
            newVector3Position.z = position.z;
            //change position based on velocity
            gameObject.transform.position = newVector3Position;
            

            
            if (velocity.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    public void SetTarget(GameObject station)
    {
        isAtFrontOfQueue = false;
        stationPosition = station.transform.position;
    }

    public void StartMoving()
    {
        move = true;
    }

    public void StopMoving()
    {
        move = false;
    }

}

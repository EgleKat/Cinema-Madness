using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_red_dot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public float speed = 0.1F;
	void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        }
    }

}

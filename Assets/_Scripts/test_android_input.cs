using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_red_dot : MonoBehaviour {
    new Camera camera;
    // Use this for initialization
    void Start () {
        camera = Camera.main;

    }

    public float speed = 0.1F;
	void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            // Get movement of the finger since last frame
            Vector3 touchPosinWorldSpace = camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, camera.nearClipPlane));
            // Move object across XY plane
            transform.position = touchPosinWorldSpace;
        }
    }

}

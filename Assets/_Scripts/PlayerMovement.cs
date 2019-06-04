using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 position;
    private Vector3 velocity;
    private Vector3 stationPosition;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = position + velocity;
    }

    public void SetTarget(ServiceStation station) {
        stationPosition = station.transform.position;
    }

    public void StartMoving() {

    }
}

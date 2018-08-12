using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanAllTheTime : MonoBehaviour {
    private AstarPath astarPath;

    // Use this for initialization
    void Start () {
        astarPath = GetComponent<AstarPath>();
	}
	
	// Update is called once per frame
	void Update () {
        astarPath.Scan();
	}
}

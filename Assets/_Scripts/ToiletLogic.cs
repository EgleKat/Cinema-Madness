using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletLogic : ServiceStation {

    float timeToServeNpc = 5;
    private bool timerRunning;
    GameObject timer;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
    }


    protected override void serveFirstNpc()
    {
        if (!locked)
        {
            Invoke("finishServingNpc", timeToServeNpc);
            timer = Instantiate(Resources.Load("Prefabs/TimerCircle") as GameObject, gameObject.transform);
            timer.GetComponent<Animator>().speed = 1 / timeToServeNpc;
            Debug.Log("Dequeing npc");
        }
    }
    protected void finishServingNpc()
    {
        unlockObject();
        waitingNpcs.Dequeue().finishTask();
        Debug.Log("Toilet Locked. Clean it!");

        //remove timer
        Destroy(timer);

    }
    /// <summary>
    /// Called when the player reaches the service
    /// </summary>
    public override void ActivateService()
    {
        unlockObject();
        serveFirstNpc();
        Debug.Log("serving first npc");
    }
}

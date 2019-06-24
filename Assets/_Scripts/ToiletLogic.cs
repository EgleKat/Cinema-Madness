using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ToiletLogic : ServiceStation {

    protected bool isClean;
    // Use this for initialization
    protected new void Awake () {
        base.Awake();
        timeToServeNpc = 5;
        isClean = true;
    }

    // Update is called once per frame
    void Update () {
    }
    /// <summary>
    /// Called after the timer runs out
    /// </summary>
    protected override void FinishServingNpc()
    {
        waitingNpcs.Dequeue().FinishTask();
        //remove timer
        Destroy(timer);
        isClean = false;
        
        MoveQueueUp();
    }
    /// <summary>
    /// Called when the player reaches the service
    /// Unlocks toilet
    /// </summary>
    public override void ActivateService()
    {
        if (!isClean)
        {
            //clean toilet
            isClean = true;
            UnlockStation();
            AcceptNpc();
        }

        playerActionQueue.FinishWithServiceStation();
    }
}

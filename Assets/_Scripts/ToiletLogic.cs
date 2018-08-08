using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletLogic : ServiceStation {


    // Use this for initialization
    protected new void Awake () {
        base.Awake();
        timeToServeNpc = 5;
    }

    // Update is called once per frame
    void Update () {
    }

    /// <summary>
    /// Called when the player reaches the service
    /// Unlocks toilet
    /// </summary>
    public override void ActivateService()
    {
        UnlockObject();
        //call player here
        playerMovement.SetFinishedTaskTrue();
        AcceptNpc();
    }
}

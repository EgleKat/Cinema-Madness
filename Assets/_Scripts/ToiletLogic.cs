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
    /// </summary>
    public override void ActivateService()
    {
        UnlockObject();
        AcceptNpc();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornStall : ServiceStation {
    InventoryManager playerInventory;

    private new void Awake()
    {
        base.Awake();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        LockStation();

    }
    public override void ActivateService()
    {
        //if player has popcorn
        if (playerInventory.HasItemWithTag("Popcorn"))
        {
            UnlockStation();
            //call player here
            AcceptNpc();
            //remove item from player
            playerInventory.RemoveItem("Popcorn");
        }
        playerActionQueue.FinishWithServiceStation();
    }

    public override void AcceptNpc()
    {
        if(!locked && waitingNpcs.Count != 0)
        {
            //don't let other npcs be accepted until the first one is finished with, make them wait!
            LockStation();
            FinishServingNpc();
        }
    }

    protected override void FinishServingNpc()
    {
        waitingNpcs.Dequeue().FinishTask();
    }

}

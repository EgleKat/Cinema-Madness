using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PopcornStall : ServiceStation {
    InventoryManager playerInventory;
    ScoreManager scoreManager;

    private new void Awake()
    {
        base.Awake();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        scoreManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();
        LockStation();

    }
    public override void ActivateService()
    {
        //if player has popcorn
        if (playerInventory.HasItemWithTag("Popcorn") && waitingNpcs.Count != 0)
        {
            UnlockStation();
            //call player here
            AcceptNpc();
            //remove item from player
            playerInventory.RemoveItem("Popcorn");
        }
        playerActionQueue.FinishWithServiceStation();
    }

    public override void AcceptNpcExtras()
    {
        if(!locked)
        {
            //don't let other npcs be accepted until the first one is finished with, make them wait!
            LockStation();
            FinishServingNpc();
        }
    }

    protected async override void FinishServingNpc()
    {
        waitingNpcs.Dequeue().FinishTask();
        scoreManager.addScoreByObject(PaidItem.Popcorn);

        foreach (NpcActionQueue waitingNpc in waitingNpcs)
        {
            Movement nextNpcMovement = waitingNpc.GetComponent<Movement>();
            if (!nextNpcMovement.isAtFrontOfQueue)
            {
                nextNpcMovement.StartMoving();
                await Task.Delay(TimeSpan.FromSeconds(0.1));
            }
        }
    }

}

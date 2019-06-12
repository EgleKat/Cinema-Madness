using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornMachine : ServiceStation
{

    InventoryManager playerInventory;
    InventoryManager popcornBoxInventory;
    protected bool filledWithPopcorn;
    protected float timeToMakePop = 3;
    public Sprite popcornSprite;
    public Sprite popcornMachineSprite;
    protected SpriteRenderer spriteRenderer;

    // Use this for initialization
    new void Awake()
    {
        base.Awake();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        playerActionQueue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActionQueue>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        filledWithPopcorn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ActivateService()
    {
        if (!filledWithPopcorn && !IsStationLocked())
        {
            
            LockStation();
            Invoke("GeneratePopcorn", timeToMakePop);
            timer = Instantiate(Resources.Load("Prefabs/TimerCircle") as GameObject, gameObject.transform);
            timer.GetComponent<Animator>().speed = 1 / timeToMakePop;


        }
        //give user the popcorn
        else if(filledWithPopcorn)
        {
            if (playerInventory.HasSpace())
            {
                playerInventory.AddItemToInventory(Resources.Load("Prefabs/Popcorn") as GameObject);
                spriteRenderer.sprite = popcornMachineSprite;
                filledWithPopcorn = false;
                UnlockStation();
            }
            else
            {
                Debug.Log("Your hands are full.");
            }

        }

        playerActionQueue.FinishWithServiceStation();

    }

    public override void AcceptNpc()
    {
        //intentionally blank
    }

    /// <summary>
    /// Generate a popcorn sprite in the popcorn machine
    /// </summary>
    protected void GeneratePopcorn()
    {
        Destroy(timer);
        spriteRenderer.sprite = popcornSprite;
        filledWithPopcorn = true;
    }
}

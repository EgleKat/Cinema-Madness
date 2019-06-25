using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ToiletLogic : ServiceStation
{

    protected bool isClean;
    private SpriteRenderer spriteRenderer;
    public Sprite closedToiletSprite;
    public Sprite openToiletSprite;
    public Sprite dirtyToiletSprite;
    private int NPCsTillDirty = 3;
    private int NPCsCountSinceCleaned = 0;
    // Use this for initialization
    protected new void Awake()
    {
        base.Awake();
        timeToServeNpc = 5;
        isClean = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// Called after the timer runs out
    /// </summary>
    protected override void FinishServingNpc()
    {
        waitingNpcs.Dequeue().FinishTask();
        //remove timer
        Destroy(timer);
        MoveQueueUp();

        NPCsCountSinceCleaned++;
        //if enough NPCs used the toilet, make it dirty
        if (NPCsCountSinceCleaned >= NPCsTillDirty)
        {
            MakeToiletDirty();
        }
        else
        {
            Debug.Log("Accepting NPC");
            spriteRenderer.sprite = openToiletSprite;
            UnlockStation();
            AcceptNpc();

        }

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
            MakeToiletClean();
            UnlockStation();
            AcceptNpc();
        }

        playerActionQueue.FinishWithServiceStation();
    }

    public override void AcceptNpc()
    {

        if (!IsStationLocked() && waitingNpcs.Count != 0)
        {
            LockStation();
            spriteRenderer.sprite = closedToiletSprite;
            //Pop the NPC off the queue
            Invoke("FinishServingNpc", timeToServeNpc);
            timer = Instantiate(Resources.Load("Prefabs/TimerCircle") as GameObject, gameObject.transform);
            timer.GetComponent<Animator>().speed = 1 / timeToServeNpc;
            timer.transform.localScale = new Vector3(0.5f, 0.5f, timer.transform.localScale.z);


        }
    }

    private void MakeToiletDirty()
    {
        isClean = false;
        spriteRenderer.sprite = dirtyToiletSprite;
    }
    private void MakeToiletClean()
    {
        NPCsCountSinceCleaned = 0;
        isClean = true;
        spriteRenderer.sprite = openToiletSprite;
    }
}

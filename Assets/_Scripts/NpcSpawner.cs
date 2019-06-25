using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    WaveManager waveManager;

    private void Awake()
    {
        waveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Destroy(collision.gameObject);
        }
    }

    internal void SpawnNPCs(int numberOfNPCs, float time)
    {
        float delayTime = time / numberOfNPCs;
        StartCoroutine(SpawnNPC(numberOfNPCs, delayTime));
    }
    IEnumerator SpawnNPC(int npcsToSpawn, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (npcsToSpawn > 0)
        {
            GameObject NPC = Instantiate(Resources.Load("Prefabs/NPC") as GameObject, gameObject.transform);
            //make the npc a random color
            //NPC.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            npcsToSpawn--;
            StartCoroutine(SpawnNPC(npcsToSpawn, delayTime));
        }
        else
        {
            waveManager.WaveFinished();
        }
    }

}

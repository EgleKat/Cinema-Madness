using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    private NpcSpawner spawner;
    private int currentWave = 0;
    private Dictionary<int, Wave> allwaves = new Dictionary<int, Wave>
    {
        {0, new Wave(4,10)},//default wave
        {1, new Wave(5, 10)},
        {2, new Wave(3, 10)}
    };

    private uint numNpcsWhoHaveExited = 0;


    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawn").GetComponent<NpcSpawner>();
    }

    private void Start()
    {
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentWave++;
        numNpcsWhoHaveExited = 0;

        Debug.Log("Starting Wave " + currentWave);

        if (allwaves.ContainsKey(currentWave))
        {
            spawner.SpawnNPCs(allwaves[currentWave].npcNo, allwaves[0].time);
        }
        else
        {
            spawner.SpawnNPCs(allwaves[0].npcNo, allwaves[0].time);
        }
    }

    public async void NpcExited()
    {
        numNpcsWhoHaveExited++;
        if (numNpcsWhoHaveExited >= allwaves[currentWave].npcNo) {
            await Task.Delay(TimeSpan.FromSeconds(5));
            StartNextWave();
        }
    }

    private class Wave
    {
        public int npcNo;
        public float time; //in seconds

        //add other information relevant to waves

        public Wave(int npcNumber, float t)
        {
            npcNo = npcNumber;
            time = t;
        }

    }
}


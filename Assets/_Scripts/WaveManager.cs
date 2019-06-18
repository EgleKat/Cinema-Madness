using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    private NpcSpawner spawner;
    private int currentWave = 1;
    private Dictionary<int, Wave> allwaves = new Dictionary<int, Wave>
    {
        {0, new Wave(4,10)},//default wave
        {1, new Wave(5, 10)},
        {2, new Wave(3, 10)}
    };


    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawn").GetComponent<NpcSpawner>();
        StartNextWave();
    }

    private void StartNextWave()
    {
        Debug.Log("Next Wave " + currentWave);
                Debug.Log(allwaves.ContainsKey(currentWave));

        if (allwaves.ContainsKey(currentWave))
        {
            spawner.SpawnNPCs(allwaves[currentWave].npcNo, allwaves[0].time);
        }
        else
        {
            Debug.Log("This level does not exist");
            spawner.SpawnNPCs(allwaves[0].npcNo, allwaves[0].time);
        }
    }

    public void WaveFinished()
    {
        currentWave++;
        StartNextWave();
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


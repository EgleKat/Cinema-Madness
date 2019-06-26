using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
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

    private GameObject canvas;


    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawn").GetComponent<NpcSpawner>();
        canvas = GameObject.Find("Canvas");
    }

    private void Start()
    {
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentWave++;
        numNpcsWhoHaveExited = 0;

        Wave currentWaveData = GetWaveDataOrDefault(currentWave);
        spawner.SpawnNPCs(currentWaveData.npcNo, currentWaveData.time);


        ShowWaveText();
    }

    private async void ShowWaveText()
    {
        GameObject waveText = Instantiate(Resources.Load("Prefabs/Wave") as GameObject, canvas.transform);
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + currentWave.ToString();
        await Task.Delay(10000);
        Destroy(waveText);
    }

    public async void NpcExited()
    {
        numNpcsWhoHaveExited++;
        if (numNpcsWhoHaveExited >= GetWaveDataOrDefault(currentWave).npcNo)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            StartNextWave();
        }
    }

    private Wave GetWaveDataOrDefault(int waveNumber)
    {
        if (allwaves.ContainsKey(waveNumber))
        {
            return allwaves[waveNumber];
        }
        else
        {
            return allwaves[0];
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


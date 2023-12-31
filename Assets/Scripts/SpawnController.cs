using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPoint;

    public float spawnTimer = 0;
    public float spawnRate = 1.0f;
    public float waveLength = 0;
    public float currentCount = 0;
    public float waveTimer = 0;
    public float waveRate = 5.0f;
    public int waveNumber = 0;
    public float agentSpeedIncrease = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("Spawner"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCount >= waveLength)
        {
            waveTimer += Time.deltaTime;
            if (waveTimer >= waveRate)
            {
                waveNumber++;
                switch (waveNumber)
                {
                    case 1:
                        StartWave1();
                        break;
                    case 2:
                        StartWave2();
                        break;
                    case 3:
                        StartWave3();
                        break;
                    default:
                        NoWaves();
                        break;
                }

                currentCount = 0;
                waveTimer = 0;
            }

            return;
        }

        if (waveNumber > 0)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                GameObject enemy = Object.Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

                //Initialize the enemy object (i.e. give it the waypoints, start it moving)
                

                //Increase enemy speed
                UnityEngine.AI.NavMeshAgent agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.speed += agentSpeedIncrease + 2;

                currentCount++;
                spawnTimer = 0;
            }
        }
    }
    void StartWave1()
    {
        Debug.Log("Starting wave 1");
        waveLength = 10;
        spawnRate = 2f;
    }

    void StartWave2()
    {
        Debug.Log("Starting wave 2");
        waveLength = 20;
        spawnRate = 1.5f;
        agentSpeedIncrease = 0.5f;
    }

    void StartWave3()
    {
        Debug.Log("Starting wave 3");
        waveLength = 40;
        spawnRate = 1f;
        agentSpeedIncrease = 1f;
    }

    void NoWaves()
    {
        Debug.Log("No more waves!");
        waveLength = 0;
        spawnRate = 10000000f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] enemySpawnPos;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int spawnCount;

    private float currnetTime;

    private void Start()
    {
        currnetTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - currnetTime > spawnTimer)
        {
            currnetTime = Time.time;

            int minSpawnCount = spawnCount - (spawnCount / 10);
            int maxSpawnCount = spawnCount + (spawnCount / 10);
            int spawnEnemyCount = Random.Range(minSpawnCount, (maxSpawnCount + 1));

            for (int i = 0; i < spawnEnemyCount; i++)
            {
                
            }
        }
    }

    private void SpawnSystem(int spawnEnemyCount)
    {
        List<int> usedSpawnListValue = new List<int>();

        for (int i = 0; i < spawnEnemyCount; i++)
        {
            int randomValue = Random.Range(0, enemySpawnPos.Length);

            if (usedSpawnListValue.Contains(randomValue) == false)
            {
                usedSpawnListValue.Add(randomValue);
                //enemySpawnPos[randomValue] 에서 스폰
            }

            else
            {
                while(true)
                {
                    randomValue = (randomValue + 1);

                    if (randomValue >= enemySpawnPos.Length)
                    {
                        randomValue = 0;
                    }

                    if (usedSpawnListValue.Contains(randomValue) == false)
                    {
                        usedSpawnListValue.Add(randomValue);
                        //enemySpawnPos[randomValue] 에서 스폰
                        return;
                    }
                }
                    
            }

            if (usedSpawnListValue.Count >= enemySpawnPos.Length)
            {
                usedSpawnListValue.Clear();
            }

        }
        

    }


}

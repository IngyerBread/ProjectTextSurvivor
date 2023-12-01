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
    /// <summary>
    /// 랜덤밸류 뽑고 해당 번호로 스폰
    /// 이미 스폰한 장소라면 내 숫자를 기억하고 스폰 가능할때까지 +1
    /// 스폰장소의 길이와 같아지면 0으로 돌리고 +1
    /// 기억한 숫자와 같아지면 소환된 장소 리스트를 초기화하고 맨 처음으로
    /// 스폰장소 리스트의 길이가 소환된 장소 리스트의 길이랑 같아지면 소환된 장소 리스트 초기화
    /// 
    /// 소환해야 할 숫자만큼 더하고 소환할때마다 소환한만큼씩 빠지는 int값
    /// 스폰장소에 소환하려 했으나 뭔가에 막혀서 소환이 안되는 장치를 넣었을때
    /// 이는 +1 루프를 돌 것인가? 돌려서 안될이유가 딱히 생각나지 않는다
    /// </summary>

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

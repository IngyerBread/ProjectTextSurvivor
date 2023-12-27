using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] enemySpawnPos;
    [SerializeField] private Transform enemySpawnPosMother;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnCountPercent;
    [SerializeField] private float spawnDistance;
    [SerializeField] private float transformCheckDistance;
    [SerializeField] private int enemySpawnPosCount;

    private float currentTime;


    private void EnemySpawnPointSetting()
    {
        Vector3 spawnAnglePos = Vector3.up;
        float spawnAnglePlus = 360 / enemySpawnPosCount; // 디그리값

        for (int i = 0; i < enemySpawnPosCount; i++)
        {
            GameObject spawnPosObject = new GameObject("EnemySpawnPoint");
            spawnPosObject.transform.parent = enemySpawnPosMother;
            spawnPosObject.transform.position = gameObject.transform.position + (spawnAnglePos * spawnDistance);
            enemySpawnPos.AddRange(spawnPosObject.transform);

            Quaternion rotation = Quaternion.Euler(0, 0, i * spawnAnglePlus);
            spawnAnglePos = rotation * Vector3.up;
        }
    }
    /// <summary>
    /// 스폰장소에 콜라이더 검사 돌렸는데 뭐가 있으면 트랜스폼 장소를 +1 반복 트랜스폼 끝까지 도달하면 0부터 다시 검사할건데
    /// 이거를 나중에 몬스터 잔뜩 쌓였을때 가정이면 이 검사 메소드가 매프레임 계속 돌아가는데 이마저도 다음 스폰시간때까지
    /// 스폰이 안됐을때는 겹치고 겹치고 똑같은 메서드들이 각자 콜라이더검사를 매 프레임하는건 너무 사고가 일어날거같음
    /// 어떻게하냐
    /// 
    /// 그것은 스폰카운트를 만들어서 메서드를 한개만 돌리게 하죠  
    /// </summary>

    private void EnemySpawn()
    {
        int i = Random.Range(0, enemySpawnPos.Length + 1);
    }
    private bool CheckSpawnPointColliderIsOn = false;
    private int spawnEnemyWaitingCount;
    private void CheckSpawnPointCollider()
    {
         if (CheckSpawnPointColliderIsOn == true) { return; }

        CheckSpawnPointColliderIsOn = true;

        while(0 < spawnEnemyWaitingCount)
        {
            spawnEnemyWaitingCount--;
        }



        CheckSpawnPointColliderIsOn = false;

    }
    private void EnemySpawnTimer()
    {
        currentTime = currentTime + Time.deltaTime;

        if (currentTime >= spawnTimer)
        {
            currentTime = 0f;

            int minSpawnCount = spawnCount - Mathf.RoundToInt(spawnCount / spawnCountPercent);
            int maxSpawnCount = spawnCount + Mathf.RoundToInt(spawnCount / spawnCountPercent);

            int spawnEnemyCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

            for (int i = 0; i < spawnEnemyCount; i++)
            {
                //에너미 스폰
            }
        }
    }
    /// <summary> 
    /// float 리스트 받고 { 20 , 20 , 10 , 25 , 25 , 0}
    /// 이런식으로 받으면 n번째 있는 숫자가 에너미[n] 나올 확률
    /// 난이도가 올라가면 새로운 float 리스트를 받아서 적용
    /// 
    /// 그냥 올랜덤 스폰장소 해버리고 스폰장소에 뭐 있으면
    /// 스폰장소를 다시 정하는게
    /// </summary>


    private void Update()
    {
        EnemySpawnTimer();
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

    //private void SpawnSystem(int spawnEnemyCount)
    //{
    //    List<int> usedSpawnListValue = new List<int>();

    //    for (int i = 0; i < spawnEnemyCount; i++)
    //    {
    //        int randomValue = Random.Range(0, enemySpawnPos.Length);

    //        if (usedSpawnListValue.Contains(randomValue) == false)
    //        {
    //            usedSpawnListValue.Add(randomValue);
    //            //enemySpawnPos[randomValue] 에서 스폰
    //        }

    //        else
    //        {
    //            while(true)
    //            {
    //                randomValue = (randomValue + 1);

    //                if (randomValue >= enemySpawnPos.Length)
    //                {
    //                    randomValue = 0;
    //                }

    //                if (usedSpawnListValue.Contains(randomValue) == false)
    //                {
    //                    usedSpawnListValue.Add(randomValue);
    //                    //enemySpawnPos[randomValue] 에서 스폰
    //                    return;
    //                }
    //            }
                    
    //        }

    //        if (usedSpawnListValue.Count >= enemySpawnPos.Length)
    //        {
    //            usedSpawnListValue.Clear();
    //        }

    //    }
        

    //}


}

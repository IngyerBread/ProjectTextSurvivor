using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] enemySpawnPos;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnCountPercent;
    [SerializeField] private float spawnDistance;
    [SerializeField] private int enemySpawnPosCount;

    private float currnetTime;


    private void EnemySpawnPointSetting()
    {
        Vector3 spawnAnglePos = Vector3.zero;
        float spawnAnglePlus = 360 / enemySpawnPosCount; // ��׸���

        // ������������ ����
        GameObject spawnPosObject = new GameObject("EnemySpawnPoint");
        spawnPosObject.transform.position = gameObject.transform.position + 
    }
    private void Start()
    {
        currnetTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - currnetTime > spawnTimer)
        {
            currnetTime = Time.time;

            int minSpawnCount = spawnCount - Mathf.RoundToInt(spawnCount / spawnCountPercent);
            int maxSpawnCount = spawnCount + Mathf.RoundToInt(spawnCount / spawnCountPercent);
            int spawnEnemyCount = Random.Range(minSpawnCount, (maxSpawnCount + 1));

            for (int i = 0; i < spawnEnemyCount; i++)
            {
                
            }
        }
    }
    /// <summary>
    /// ������� �̰� �ش� ��ȣ�� ����
    /// �̹� ������ ��Ҷ�� �� ���ڸ� ����ϰ� ���� �����Ҷ����� +1
    /// ��������� ���̿� �������� 0���� ������ +1
    /// ����� ���ڿ� �������� ��ȯ�� ��� ����Ʈ�� �ʱ�ȭ�ϰ� �� ó������
    /// ������� ����Ʈ�� ���̰� ��ȯ�� ��� ����Ʈ�� ���̶� �������� ��ȯ�� ��� ����Ʈ �ʱ�ȭ
    /// 
    /// ��ȯ�ؾ� �� ���ڸ�ŭ ���ϰ� ��ȯ�Ҷ����� ��ȯ�Ѹ�ŭ�� ������ int��
    /// ������ҿ� ��ȯ�Ϸ� ������ ������ ������ ��ȯ�� �ȵǴ� ��ġ�� �־�����
    /// �̴� +1 ������ �� ���ΰ�? ������ �ȵ������� ���� �������� �ʴ´�
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
                //enemySpawnPos[randomValue] ���� ����
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
                        //enemySpawnPos[randomValue] ���� ����
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

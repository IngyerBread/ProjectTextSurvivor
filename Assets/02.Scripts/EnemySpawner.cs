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
        float spawnAnglePlus = 360 / enemySpawnPosCount; // ��׸���

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
    /// ������ҿ� �ݶ��̴� �˻� ���ȴµ� ���� ������ Ʈ������ ��Ҹ� +1 �ݺ� Ʈ������ ������ �����ϸ� 0���� �ٽ� �˻��Ұǵ�
    /// �̰Ÿ� ���߿� ���� �ܶ� �׿����� �����̸� �� �˻� �޼ҵ尡 �������� ��� ���ư��µ� �̸����� ���� �����ð�������
    /// ������ �ȵ������� ��ġ�� ��ġ�� �Ȱ��� �޼������ ���� �ݶ��̴��˻縦 �� �������ϴ°� �ʹ� ��� �Ͼ�Ű���
    /// ����ϳ�
    /// 
    /// �װ��� ����ī��Ʈ�� ���� �޼��带 �Ѱ��� ������ ����  
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
                //���ʹ� ����
            }
        }
    }
    /// <summary> 
    /// float ����Ʈ �ް� { 20 , 20 , 10 , 25 , 25 , 0}
    /// �̷������� ������ n��° �ִ� ���ڰ� ���ʹ�[n] ���� Ȯ��
    /// ���̵��� �ö󰡸� ���ο� float ����Ʈ�� �޾Ƽ� ����
    /// 
    /// �׳� �÷��� ������� �ع����� ������ҿ� �� ������
    /// ������Ҹ� �ٽ� ���ϴ°�
    /// </summary>


    private void Update()
    {
        EnemySpawnTimer();
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

    //private void SpawnSystem(int spawnEnemyCount)
    //{
    //    List<int> usedSpawnListValue = new List<int>();

    //    for (int i = 0; i < spawnEnemyCount; i++)
    //    {
    //        int randomValue = Random.Range(0, enemySpawnPos.Length);

    //        if (usedSpawnListValue.Contains(randomValue) == false)
    //        {
    //            usedSpawnListValue.Add(randomValue);
    //            //enemySpawnPos[randomValue] ���� ����
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
    //                    //enemySpawnPos[randomValue] ���� ����
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

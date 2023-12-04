using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHP = 100f;

    public void EnemyGetDamaged(float damage)
    {
        Debug.Log("EnemyGetDamaged");
        enemyHP = enemyHP - damage;

        if (enemyHP <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        Debug.Log(gameObject.name + "has Die");

        Destroy(gameObject);
    }
}

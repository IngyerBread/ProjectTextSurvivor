using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Connect Component")]
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private Transform playerFirePos;


    private float attackTimer = 0f;
    private float fireSpeed = 100f;

    private void Start()
    {
        fireSpeed = PlayerMove.instance._attackSpeed;
    }

    private void Update()
    {
        attackTimer = attackTimer + Time.deltaTime;

        if (attackTimer >= fireSpeed)
        {
            FireBullet();
            attackTimer = 0f;
        }
    }

    private void FireBullet()
    {
        GameObject playerBulletGO = Instantiate(playerBulletPrefab);
        playerBulletGO.transform.position = playerFirePos.transform.position;
        //방향설정
    }
}

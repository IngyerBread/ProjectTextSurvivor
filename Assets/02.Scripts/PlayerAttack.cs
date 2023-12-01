using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Connect Component")]
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private Transform playerFirePos;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform canvas;


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
        GameObject playerBulletGO = Instantiate(playerBulletPrefab, canvas);
        playerBulletGO.transform.position = playerFirePos.transform.position;
        playerBulletGO.GetComponent<Bullet>().BulletSetting(bulletSpeed, (playerFirePos.transform.position - gameObject.transform.position).normalized);
    }
}

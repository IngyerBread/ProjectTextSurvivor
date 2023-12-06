using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    [Header("Connect Component")]
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private Transform playerFirePos;
    [SerializeField] private Transform canvas;

    private float battleEnterAttackDamage = 10f;
    private float inGameAttackDamage;
    private float currentAttackDamage;

    private float battleEnterAttackSpeed = 100f;
    private float inGameAttackSpeed;
    private float currentAttackSpeed;

    private float battleEnterFireObjectSpeed = 500f;
    private float inGameFireObjectSpeed;
    private float currentFireObjectSpeed;

    private float attackTimer = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GetAttackValue(float _playerAttackDamage, float _playerAttackSpeed, float _fireObjectSpeed)
    {
        battleEnterAttackDamage = _playerAttackDamage;
        inGameAttackDamage = battleEnterAttackDamage;
        currentAttackDamage = inGameAttackDamage;

        battleEnterAttackSpeed = _playerAttackSpeed;
        inGameAttackSpeed = battleEnterAttackSpeed;
        currentAttackSpeed = inGameAttackSpeed;

        battleEnterFireObjectSpeed = _fireObjectSpeed;
        inGameFireObjectSpeed = battleEnterFireObjectSpeed;
        currentFireObjectSpeed = inGameFireObjectSpeed;
    }
    private void Update()
    {
        attackTimer = attackTimer + Time.deltaTime;

        if (attackTimer >= battleEnterAttackSpeed)
        {
            FireBullet();
            attackTimer = 0f;
        }
    }

    private void FireBullet()
    {
        GameObject playerBulletGO = Instantiate(playerBulletPrefab, canvas);
        playerBulletGO.transform.position = playerFirePos.transform.position;
        playerBulletGO.GetComponent<Bullet>().BulletSetting(battleEnterFireObjectSpeed, (playerFirePos.transform.position - gameObject.transform.position).normalized, battleEnterAttackDamage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDamage;
    private float bulletSpeed;
    private Vector3 targetVector;

    private void OnEnable()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + (targetVector * bulletSpeed * Time.deltaTime);
        gameObject.transform.up = targetVector;
    }

    public void BulletSetting(float bulletSpeedValue, Vector3 VectorValue, float damageValue)
    {
        bulletSpeed = bulletSpeedValue;
        targetVector = VectorValue;
        bulletDamage = damageValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("!");
            collision.gameObject.GetComponent<Enemy>().EnemyGetDamaged(bulletDamage);
            Destroy(gameObject);
        }
    }
}

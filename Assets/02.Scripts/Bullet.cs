using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed;
    private Vector3 targetVector;

    private void OnEnable()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + (targetVector * bulletSpeed * Time.deltaTime);
    }

    public void BulletSetting(float bulletSpeedValue, Vector3 VectorValue)
    {
        bulletSpeed = bulletSpeedValue;
        targetVector = VectorValue;
    }
}

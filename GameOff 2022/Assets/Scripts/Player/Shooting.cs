using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting instance;

    [Header("References")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform shootDirection;

    [Space]
    [Header("Bullet Effects")]
    [Range(0.1f, 20.0f)]
    public float bulletDamage = 1.0f;

    [Space]
    [Header("Bullet Properties")]
    [Range(0.1f, 20.0f)]
    public float bulletSpeed = 1.0f;
    [Range(0.1f, 20.0f)]
    public float bulletSize = 1.0f;
    [Range(0.1f, 20.0f)]
    public float bulletLifetime = 1.0f;
    public bool bulletPiercing;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
            Vector2 direction = (shootDirection.position - bulletSpawnPoint.position).normalized;

            bulletScript.SetStats(bulletDamage, bulletSpeed, bulletSize, bulletLifetime, direction, bulletPiercing);
        }
    }
}

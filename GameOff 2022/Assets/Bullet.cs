using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    public GameObject hitObject;
    public Rigidbody2D rb;

    [Space]
    [Header("Bullet Effects")]
    public float _bulletDamage;

    [Space]
    [Header("Bullet Properties")]
    public float _bulletSpeed;
    public float _bulletSize;
    public float _bulletLifetime;
    public bool _bulletPiercing;

    Vector2 _direction;

    void Start()
    {
        ImplementStats();
    }

    void Update()
    {
        
    }

    public void SetStats(float bulletDamage, float bulletSpeed, float bulletSize, float bulletLifetime, Vector2 direction, bool bulletPiercing)
    {
        _bulletDamage = bulletDamage;
        _bulletSpeed = bulletSpeed;
        _bulletSize = bulletSize;
        _bulletLifetime = bulletLifetime;
        _bulletPiercing = bulletPiercing;

        _direction = direction;
    }

    void ImplementStats()
    {
        rb.velocity = (_direction * _bulletSpeed);
        transform.localScale = new Vector3(_bulletSize, _bulletSize, 1.0f);
        Destroy(this.gameObject, _bulletLifetime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Shootable>())
        {
            collider.GetComponent<Shootable>().GetDamage(_bulletDamage);
            if(!_bulletPiercing)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

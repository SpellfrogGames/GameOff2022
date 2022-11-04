using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health = 1.0f;
    public float damage = 0.0f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Get Damage: " + damage);

        if(health <= 0.0f)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Debug.Log("I "+ name + " dieded");
        Destroy(this.gameObject);
    }
}

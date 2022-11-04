using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public float health = 1.0f;

    public void GetDamage(float damage)
    {
        health -= damage;
        Debug.Log("Get Damage: " + damage);

        if(health <= 0.0f)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("I "+ name + " dieded");
        Destroy(this.gameObject);
    }
}

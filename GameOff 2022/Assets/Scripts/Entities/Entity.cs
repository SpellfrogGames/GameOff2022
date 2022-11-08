using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health = 1.0f;
    public float damage = 0.0f;

    [Space]
    public GameObject[] itemsToDrop;

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
        DropLoot();
        Destroy(this.gameObject);
    }

    public virtual void DropLoot()
    {
        if(itemsToDrop != null)
        {
            foreach(GameObject item in itemsToDrop)
            {
                GameObject lootInstance = Instantiate(item, transform.position, Quaternion.identity);
            }
        }
    }
}

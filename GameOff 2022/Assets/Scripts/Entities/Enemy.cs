using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Player Finding")]
    public float movementSpeed;

    [Space]
    [Header("Attack")]
    public LayerMask whatCanIAttack;
    public float secondsBtwAttacks;
    private float timeBtwAttack;
    public float attackRange;

    [Space]
    [Header("References")]
    public Rigidbody2D rb;
    public Transform attackOrigin;

    void Update()
    {
        FindingPlayer();
        Attacking();
    }

    void FindingPlayer()
    {
        rb.velocity = (Player.instance.transform.position - transform.position) * movementSpeed * Time.fixedDeltaTime;
    }

    void Attacking()
    {
        if(timeBtwAttack <= 0)
        {
            DealDamage();
            timeBtwAttack = secondsBtwAttacks;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void DealDamage()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackOrigin.position, attackRange, whatCanIAttack);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Entity>().TakeDamage(damage);
        }
    }
    
    public override void Death()
    {
        base.Death();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
    }
}


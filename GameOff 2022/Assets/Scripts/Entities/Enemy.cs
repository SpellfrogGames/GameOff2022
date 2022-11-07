using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Player Finding")]
    public float baseMovementSpeed;
    public float movementSpeed;
    public float closeArea;

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

    void Start()
    {
        GameplayManager.instance.enemies.Add(this.transform);
        GameplayManager.instance.RefreshEnemiesCount();
    }

    void Update()
    {
        FindingPlayer();
        Attacking();
    }

    void FindingPlayer()
    {
        if(Player.instance)
        {
            if(Vector2.Distance(transform.position, Player.instance.transform.position) > closeArea)
            {
                movementSpeed = baseMovementSpeed * 2; 
            }
            else
            {
                movementSpeed = baseMovementSpeed;
            }
            
            rb.velocity = (Player.instance.transform.position - transform.position).normalized * movementSpeed * Time.fixedDeltaTime;
        }
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
        GameplayManager.instance.enemies.Remove(this.gameObject.transform);
        base.Death();
        GameplayManager.instance.RefreshEnemiesCount();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
    }
}


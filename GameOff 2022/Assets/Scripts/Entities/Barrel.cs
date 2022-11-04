using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Entity
{
    public Transform explosionOrigin;
    public LayerMask whatCanIDamage;
    public float explosionRange;

    void Update()
    {
        
    }

    public override void Death()
    {
        base.Death();
        Explode();
    }

    void Explode()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(explosionOrigin.position, explosionRange, whatCanIDamage);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Entity>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(explosionOrigin.position, explosionRange);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoins = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoins -= damage;

        if (hitPoins <= 0)
        {
            Die();  
        }
        
    }
    void Die()
    {
        if (isDead) return;
        isDead = true;
       
        GetComponent<Animator>().SetTrigger("die");
    }
}



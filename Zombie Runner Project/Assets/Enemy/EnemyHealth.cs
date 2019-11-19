using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthAmount = 100f;

    EnemyAI enemyAI;

    public bool IsAlive()
    {
        return healthAmount > 0;
    }

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void Damage(float damageAmount)
    {
        if (IsAlive() && damageAmount > 0)
        {
            healthAmount -= damageAmount;

            enemyAI.Provoke();

            if (IsAlive() == false)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        enemyAI.Die();
    }
}

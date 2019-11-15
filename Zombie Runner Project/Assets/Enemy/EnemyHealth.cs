using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthAmount = 100f;

    EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }



    public void Damage(float damageAmount)
    {
        if (damageAmount > 0)
        {
            healthAmount -= damageAmount;

            enemyAI.Provoke();

            if (healthAmount <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

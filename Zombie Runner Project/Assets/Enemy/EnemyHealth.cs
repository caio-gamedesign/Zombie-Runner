using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthAmount = 100f;

    public void Damage(float damageAmount)
    {
        Debug.Log(damageAmount);
        if (damageAmount > 0)
        {
            healthAmount -= damageAmount;
        }

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

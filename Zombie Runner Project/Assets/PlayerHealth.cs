using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthAmount = 100f;
    bool isAlive = true;

    public void Damage(int damage)
    {
        if (damage > 0 && isAlive)
        {
            healthAmount -= damage;

            if (healthAmount <= 0)
            {
                Die();
            }

        }
    }

    private void Die()
    {
        isAlive = false;
        GetComponent<DeathHandler>().HandleDeath();
    }
}

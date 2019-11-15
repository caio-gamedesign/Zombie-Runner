using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthAmount = 100f;

    public void Damage(int damage)
    {
        if (damage > 0)
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
        Debug.Log("You Died");
    }
}

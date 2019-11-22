using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthAmount = 100f;
    bool isAlive = true;
    DisplayDamage displayDamage;

    private void Start()
    {
        displayDamage = GetComponent<DisplayDamage>();
    }

    public void Damage(int damage, string direction = "")
    {
        if (damage > 0 && isAlive)
        {
            displayDamage.ShowDamage(direction);
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

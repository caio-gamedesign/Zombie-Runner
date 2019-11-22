using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int damage = 20;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void HitFromLeft()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().Damage(damage, DisplayDamage.LEFT);
    }

    public void HitFromRight()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().Damage(damage, DisplayDamage.RIGHT);
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().Damage(damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int damage = 40;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().Damage(damage);
    }
}

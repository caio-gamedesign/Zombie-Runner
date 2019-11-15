using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 15f;

    NavMeshAgent navMeshAgent;
    Animator animator;

    bool isProvoked;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    bool IsTargetInRange()
    {
        return DistanceToTarget() <= chaseRange;
    }

    float DistanceToTarget()
    {
        return Vector3.Distance(target.position, transform.position);
    }

    void Update()
    {
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (IsTargetInRange())
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (DistanceToTarget() > navMeshAgent.stoppingDistance)
        {
            Chase();
        }
        else
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetBool("attack", true);
        Debug.Log(name + " is attacking " + target.name);
    }

    private void Chase()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
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
    [SerializeField] float turnSpeed = 5f;

    public void Provoke()
    {
        isProvoked = true;
    }

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
        FaceTarget();
        if (DistanceToTarget() > navMeshAgent.stoppingDistance)
        {
            Chase();
        }
        else
        {
            Attack();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void Attack()
    {
        animator.SetBool("attack", true);
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
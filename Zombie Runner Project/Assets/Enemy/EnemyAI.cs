using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
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
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    bool IsTargetInRange()
    {
        return HorizontalDistanceSq() <= (chaseRange * chaseRange);
    }

    void Update()
    {
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (IsTargetInRange())
        {
            Provoke();
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (IsInAttackRange())
        {
            Attack();
        }
        else
        {
            Chase();
        }
    }

    private float HorizontalDistanceSq()
    {
        float xDist = target.position.x - transform.position.x;
        float zDist = target.position.z - transform.position.z;

        return (xDist * xDist) + (zDist * zDist);
    }

    private bool IsInAttackRange()
    {
        float horizontalRange = navMeshAgent.stoppingDistance;

        return HorizontalDistanceSq() <= (horizontalRange * horizontalRange);
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

    public void Die()
    {
        animator.SetTrigger("die");
        navMeshAgent.isStopped = true;
    }

    public void DeatchZombieCorpse()
    {
        transform.DetachChildren();
        Destroy(gameObject);
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
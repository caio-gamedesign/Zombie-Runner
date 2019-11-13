using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        if (IsTargetInRange())
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        navMeshAgent.isStopped = true;
        float yRotation = Mathf.Sin(Time.time/4) * 180 ;
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void Chase()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
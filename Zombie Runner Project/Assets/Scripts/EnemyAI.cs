using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distanceToChase = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget;

    float catetoX, catetoY, catetoZ;
    float catetoXSQ, catetoYSQ, catetoZSQ;
    float hipotenusaSQ;
    float hipotenusa;
    float distSQ;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        catetoX = (target.position.x - transform.position.x);
        catetoY = (target.position.y - transform.position.y);
        catetoZ = (target.position.z - transform.position.z);

        catetoXSQ = catetoX * catetoX;
        catetoYSQ = catetoY * catetoY;
        catetoZSQ = catetoZ * catetoZ;

        hipotenusaSQ = catetoXSQ + catetoYSQ + catetoZSQ;
        hipotenusa = Mathf.Sqrt(hipotenusaSQ);

        distSQ = distanceToChase * distanceToChase;

        if (distanceToTarget <= distanceToChase)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [Range(1,100)][SerializeField] int damage = 25;
    [SerializeField] float range = 100f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " hitted");

            if (hit.transform.CompareTag("Enemy"))
            {  
                hit.transform.GetComponent<EnemyHealth>().Damage(damage);
            }
        }
    }
}

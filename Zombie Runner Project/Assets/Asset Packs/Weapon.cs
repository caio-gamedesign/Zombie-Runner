using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [Range(1,100)][SerializeField] int damage = 25;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();

        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            if (hit.transform.CompareTag("Enemy"))
            {  
                hit.transform.GetComponent<EnemyHealth>().Damage(damage);
            }
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        Destroy(Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)), .075f);
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}

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
    [SerializeField] Ammo ammoSlot;

    [SerializeField] float secondsBetweenShots;
    private float lastShotTime = 0f;

    WeaponZoom weaponZoom;

    private void Start()
    {
        weaponZoom = GetComponent<WeaponZoom>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetButton("Fire2"))
            {
                weaponZoom.FOVZoomIn();
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                weaponZoom.FOVZoomOut();
            }

            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
    }

    private bool CanFire()
    {
        float deltaShotTime = Time.time - lastShotTime;

        return ammoSlot.Amount > 0 && deltaShotTime >= secondsBetweenShots;
    }

    private void Shoot()
    {
        if (CanFire()) 
        {
            lastShotTime = Time.time;
            ammoSlot.ReduceAmmo();
            PlayMuzzleFlash();
            ProcessRayCast();
        }
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
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

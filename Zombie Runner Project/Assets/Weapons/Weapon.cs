using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [Range(1, 100)] [SerializeField] int damage = 25;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammo;

    [SerializeField] float secondsBetweenShots;
    private float lastShotTime = 0f;

    WeaponZoom weaponZoom;

    [SerializeField] AmmoType ammoType;    

    private void Awake()
    {
        weaponZoom = GetComponent<WeaponZoom>();
        ammo = transform.root.GetComponent<Ammo>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetButtonDown("Fire2"))
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

    private void OnEnable()
    {
        ammo.UpdateAmmoDisplay(ammoType);
    }

    private void OnDisable()
    {
        weaponZoom.FOVZoomOut();
    }

    private bool CanFire()
    {
        float deltaShotTime = Time.time - lastShotTime;
        bool isOnFireRate = deltaShotTime >= secondsBetweenShots;

        bool hasAmmo = ammo.Amount(ammoType) > 0;

        return isOnFireRate && hasAmmo;
    }

    private void Shoot()
    {
        if (CanFire())
        {
            lastShotTime = Time.time;

            PlayMuzzleFlash();
            ProcessRayCast();

            ammo.ReduceAmmo(ammoType);
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

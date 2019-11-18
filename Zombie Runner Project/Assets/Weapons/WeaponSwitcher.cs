using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int initialWeapon = 0;
    int currentWeapon = -1;
    int weaponsAmount = -1;

    void Start()
    {
        SetWeaponsAmount();
        DeactivateAllWeapons();
        SetWeaponActive(initialWeapon);
    }

    private void SetWeaponsAmount()
    {
        weaponsAmount = transform.childCount;
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            ProcessScroll();
            ProcessKeyInput();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            SetWeaponActive(0);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            SetWeaponActive(1);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            SetWeaponActive(2);
        }
    }

    private void ProcessScroll()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput < 0)
        {
            SetWeaponActive(NextWeapon());
        }
        else if (scrollInput > 0)
        {
            SetWeaponActive(PreviousWeapon());
        }
    }

    private int NextWeapon()
    {
        return (currentWeapon + 1) % weaponsAmount;
    }

    private int PreviousWeapon()
    {
        int weaponIndex = currentWeapon - 1;
        while (weaponIndex < 0)
        {
            weaponIndex += weaponsAmount;
        }

        return weaponIndex % weaponsAmount;
    }

    private void DeactivateAllWeapons()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        currentWeapon = -1;
    }

    private void SetWeaponActive(int weaponIndex)
    {
        if (ShouldChangeWeapon(weaponIndex))
        {
            if (currentWeapon >= 0)
            {
                transform.GetChild(currentWeapon).gameObject.SetActive(false);
            }

            transform.GetChild(weaponIndex).gameObject.SetActive(true);
            currentWeapon = weaponIndex;
        }
    }

    private bool ShouldChangeWeapon(int weaponIndex)
    {
        bool isCurrentWeapon = weaponIndex == currentWeapon;
        bool isValidIndex = weaponIndex >= 0 && weaponIndex < weaponsAmount;

        return isCurrentWeapon == false && isValidIndex == true;
    }
}

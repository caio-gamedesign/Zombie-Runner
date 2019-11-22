using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    [SerializeField] TextMeshProUGUI ammoDisplay;

    public void UpdateAmmoDisplay(AmmoType ammoType)
    {
        ammoDisplay.text = Amount(ammoType).ToString();
    }

    public int Amount (AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    internal void GetPickUp(AmmoType ammoType, int ammoAmount)
    {
        IncreaseAmmo(ammoType, ammoAmount);
    }

    public void IncreaseAmmo(AmmoType ammoType, int amount = 1)
    {
        GetAmmoSlot(ammoType).ammoAmount += amount;
        UpdateAmmoDisplay(ammoType);
    }

    public void ReduceAmmo(AmmoType ammoType, int amount = 1)
    {
        GetAmmoSlot(ammoType).ammoAmount -= amount;
        UpdateAmmoDisplay(ammoType);
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}

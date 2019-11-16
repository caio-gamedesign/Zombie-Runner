using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int amount = 10;

    public int Amount
    {
        get { return amount; }
    }

    public void ReduceAmmo()
    {
        amount--;
    }


}

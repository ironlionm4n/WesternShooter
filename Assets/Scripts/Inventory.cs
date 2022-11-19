using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapons[] weapons;

    private void Update()
    {
        foreach (var weapon in weapons)
        {
            if (Input.GetKeyDown(weapon.WeaponHotKey))
            {
                SwitchToWeapon(weapon);
                break;
            }
        }
    }

    private void SwitchToWeapon(Weapons switchingWeapon)
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == switchingWeapon);
        }
    }
}

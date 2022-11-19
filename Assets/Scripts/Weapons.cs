using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private KeyCode weaponHotKey;
    public KeyCode WeaponHotKey => weaponHotKey;
    
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (CanFireWeapon())
            {
                FireWeapon();
            }
        }
    }

    private void FireWeapon()
    {
        Debug.Log("Firing Weapon "+ gameObject.name);
    }

    private bool CanFireWeapon()
    {
        return true;
    }
}

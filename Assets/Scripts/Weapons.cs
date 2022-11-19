using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private KeyCode weaponHotKey;
    [SerializeField] private float fireDelay = .55f;
    private float fireTimer;
    
    public KeyCode WeaponHotKey => weaponHotKey;
    // assigning an empty delegate prevents a null exception
    public event Action OnFire = delegate { };
    
    private void Update()
    {
        fireTimer += Time.deltaTime;
        
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
        fireTimer = 0f;
        OnFire(); // anything listening to this event will invoke
        Debug.Log("Firing Weapon "+ gameObject.name);
    }

    private bool CanFireWeapon()
    {
        return fireTimer >= fireDelay;
    }
    
}

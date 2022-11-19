using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Weapons))]
public class WeaponAnimation : MonoBehaviour
{
    private Weapons weapon;
    private Animator animator;
    private static readonly int Fire = Animator.StringToHash("Fire");

    private void Awake()
    {
        weapon = GetComponent<Weapons>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        weapon.OnFire += Weapon_OnFire;
    }

    private void Weapon_OnFire()
    {
        // play weapon animation
        animator.SetTrigger(Fire);
    }

    private void OnDestroy()
    {
        weapon.OnFire -= Weapon_OnFire;
    }
}

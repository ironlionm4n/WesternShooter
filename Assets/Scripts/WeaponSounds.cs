using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Weapons))]
public class WeaponSounds : WeaponComponent
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    protected override void WeaponFired()
    {
        audioSource.Play();
    }
}
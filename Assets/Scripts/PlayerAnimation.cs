using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float blendWeaponSpeed;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FadeToShootingLayer());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(FadeFromShootingLayer());
        }
    }

    private IEnumerator FadeFromShootingLayer()
    {
        float currentWeight = playerAnimator.GetLayerWeight(1);
        float elapsedTime = 0f;

        while (elapsedTime < blendWeaponSpeed)
        {
            elapsedTime += Time.deltaTime;
            currentWeight -= Time.deltaTime / blendWeaponSpeed;
            playerAnimator.SetLayerWeight(1, currentWeight);
            yield return null;
        }
        
        playerAnimator.SetLayerWeight(1, 0);
    }

    private IEnumerator FadeToShootingLayer()
    {
        float currentWeight = playerAnimator.GetLayerWeight(1);
        float elapsedTime = 0f;

        while (elapsedTime < blendWeaponSpeed)
        {
            elapsedTime += Time.deltaTime;
            currentWeight += Time.deltaTime / blendWeaponSpeed;
            playerAnimator.SetLayerWeight(1, currentWeight);
            yield return null;
        }
        
        playerAnimator.SetLayerWeight(1, 1);
    }
}

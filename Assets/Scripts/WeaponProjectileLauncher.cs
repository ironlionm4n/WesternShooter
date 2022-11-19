using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapons))]
public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField] private Rigidbody projectileRb;
    [SerializeField] private float projectileVelocity = 40f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDistance;
    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Vector3 direction = GetDirection();
        var projectile = Instantiate(projectileRb, transform.position, Quaternion.Euler(direction));
        projectile.velocity = direction * projectileVelocity;
    }

    // calculate the direction where we are facing 
    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        // point 300 units away to aim by default in case nothing was hit on layer mask
        Vector3 target = ray.GetPoint(300); 
        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }
        // direction variable has the magnitude and the direction
        Vector3 direction = target - transform.position;
        // normalize it to disregard the magnitude and only care about the direction
        direction.Normalize();
        return direction;
    }
}
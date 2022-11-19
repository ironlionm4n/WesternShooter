using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    private Weapons weapon;
    // every class which inherits this class will be forced to implement WeaponFired()
    protected abstract void WeaponFired();

    private void Awake()
    {
        weapon = GetComponent<Weapons>();
        weapon.OnFire += WeaponFired;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= WeaponFired;
    }
}
using System;
using UnityEngine;

public class ADamageable : MonoBehaviour
{
    public DHealth HealthComp;

    public void DealDamage(UInt32 damage)
    {
        Debug.Log(name + " DealDamage()");

        // If we have a health component, subtract the damage from the health:
        if (HealthComp) {
            HealthComp.SubtractHealth(damage);
        }
    }
}

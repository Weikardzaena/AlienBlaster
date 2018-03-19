using System;
using UnityEngine;

public class ADamageable : MonoBehaviour
{
    private HealthComp mHealthComp;
    private DestroyableComp mDestroyableComp;

    // Use this for initialization
    void Start()
    {
        mHealthComp = GetComponent<HealthComp>();
    }

    public void DealDamage(UInt32 damage)
    {
        Debug.Log(name + " DealDamage()");

        // If we have a health component, subtract the damage from the health:
        if (mHealthComp != null) {
            mHealthComp.SubtractHealth(damage);
        }
    }
}

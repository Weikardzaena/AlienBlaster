﻿using UnityEngine;

public class BCollisionDamage : MonoBehaviour
{
    public uint DamageVal = 1;

    public void OnTriggerEnter(Collider other)
    {
        // There's no way of getting around checking for the Damageable Component at hit
        // since we don't know what object we're going to hit ahead of time.  And since
        // we're not going to be calling this every frame, there's no performance issue
        // (not tested, but it makes sense to think that way).
        var damageComp = other.gameObject.GetComponent<ADamageable>();

        if (damageComp != null) {
            damageComp.DealDamage(DamageVal);
        }
    }
}

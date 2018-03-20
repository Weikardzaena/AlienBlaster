﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class BExplosionDmg : MonoBehaviour, IResettable
{
    public SphereCollider ExplosionArea;
    public UInt32 Damage;

    private HashSet<ADamageable> mTargets = new HashSet<ADamageable>();

    // Use this for initialization
    void OnEnable()
    {
        Reset();
    }

    void OnTriggerEnter(Collider other)
    {
        var damageComp = other.gameObject.GetComponent<ADamageable>();
        if (damageComp != null) {
            mTargets.Add(damageComp);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var damageComp = other.gameObject.GetComponent<ADamageable>();
        if (damageComp != null) {
            mTargets.Remove(damageComp);
        }
    }

    public void Detonate()
    {
        foreach (var target in mTargets) {
            if (target != null) {
                target.DealDamage(Damage);
            }
        }
    }

    public void Reset()
    {
        // Override trigger to ensure there's no actual collision that occurs for rigid bodies:
        ExplosionArea.isTrigger = true;

        mTargets.Clear();
    }
}

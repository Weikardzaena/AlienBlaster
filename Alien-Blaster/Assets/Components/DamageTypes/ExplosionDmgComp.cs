using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDmgComp : MonoBehaviour
{
    public SphereCollider ExplosionArea;
    public UInt32 Damage;

    private HashSet<DamageableComp> mTargets = new HashSet<DamageableComp>();

    // Use this for initialization
    void Start()
    {
        // Override trigger to ensure there's no actual collision that occurs for rigid bodies:
        ExplosionArea.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        var damageComp = other.gameObject.GetComponent<DamageableComp>();
        if (damageComp != null) {
            mTargets.Add(damageComp);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var damageComp = other.gameObject.GetComponent<DamageableComp>();
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
}

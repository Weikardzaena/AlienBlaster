using System;
using System.Collections.Generic;
using UnityEngine;

public class B_AOE_DOT : MonoBehaviour
{
    public UInt32 Damage = 1;
    public float DamagePeriod = 0.1f;

    private UInt32 mDamage;
    private float mNextFireTime;
    private float mPeriod;
    private HashSet<ADamageable> mTargets = new HashSet<ADamageable>();

    // Use this for initialization
    void OnEnable()
    {
        mDamage = Damage;
        mPeriod = DamagePeriod;
        mTargets.Clear();
        mNextFireTime = 0.0f;
    }

    void Update()
    {
        mNextFireTime -= Time.deltaTime;

        if (mNextFireTime < 0.0f) {
            mNextFireTime = mPeriod;

            // Remove references to destroyed objects:
            // TODO:  IS this even necessary??
            mTargets.RemoveWhere(x => x == null);

            foreach (var target in mTargets) {
                target.DealDamage(mDamage);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ADamageable otherDamageable = other.gameObject.GetComponent<ADamageable>();
        if (otherDamageable) {
            mTargets.Add(otherDamageable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        ADamageable otherDamageable = other.gameObject.GetComponent<ADamageable>();
        if (otherDamageable) {
            mTargets.Remove(otherDamageable);
        }
    }
}

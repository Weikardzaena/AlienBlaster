using System;
using System.Collections.Generic;
using UnityEngine;

public class AOE_DOT_Comp : MonoBehaviour
{
    public UInt32 Damage = 1;
    public float DamagePeriod = 0.1f;

    private UInt32 mDamage;
    private float mNextFireTime = 0.0f;
    private float mPeriod;
    private HashSet<DamageableComp> mTargets = new HashSet<DamageableComp>();

	// Use this for initialization
	void Start () {
        mDamage = Damage;
        mPeriod = DamagePeriod;
	}

    void Update()
    {
        mNextFireTime -= Time.deltaTime;

        if (mNextFireTime < 0.0f) {
            mNextFireTime = mPeriod;

            // Remove references to destroyed objects:
            mTargets.RemoveWhere(x => x == null);

            foreach (var target in mTargets) {
                target.DealDamage(mDamage);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        DamageableComp otherDamageable = other.gameObject.GetComponent<DamageableComp>();
        if (otherDamageable) {
            mTargets.Add(otherDamageable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        DamageableComp otherDamageable = other.gameObject.GetComponent<DamageableComp>();
        if (otherDamageable) {
            mTargets.Remove(otherDamageable);
        }
    }
}

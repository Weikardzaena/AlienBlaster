using System;
using System.Collections.Generic;
using UnityEngine;

public class AOE_DOT_Comp : MonoBehaviour
{
    public UInt32 Damage = 1;
    public float DamagePeriod = 0.1f;

    private UInt32 mDamage;
    private float mPeriod;
    private HashSet<DOTSrcMgrComp> mTargets = new HashSet<DOTSrcMgrComp>();

	// Use this for initialization
	void Start () {
        ChangeDmgAndPeriod(Damage, DamagePeriod);
	}

    void OnTriggerEnter(Collider other)
    {
        DOTSrcMgrComp otherDOTmgr = other.gameObject.GetComponent<DOTSrcMgrComp>();
        if (otherDOTmgr) {
            otherDOTmgr.AddDOTSource(mPeriod, mDamage, this);
            mTargets.Add(otherDOTmgr);
        }
    }

    void OnTriggerExit(Collider other)
    {
        DOTSrcMgrComp otherDOTmgr = other.gameObject.GetComponent<DOTSrcMgrComp>();
        if (otherDOTmgr) {
            otherDOTmgr.RemoveDOTSource(this);
            mTargets.Remove(otherDOTmgr);
        }
    }

    void OnDestroy()
    {
        foreach (var target in mTargets) {
            target.RemoveDOTSource(this);
        }
    }

    public void ChangeDamage(UInt32 newDamage)
    {
        mDamage = newDamage;

        UpdateAllTargets();
    }

    public void ChangePeriod(float newPeriod)
    {
        mPeriod = newPeriod;

        UpdateAllTargets();
    }

    public void ChangeDmgAndPeriod(UInt32 newDamage, float newPeriod)
    {
        mDamage = newDamage;
        mPeriod = newPeriod;

        UpdateAllTargets();
    }

    private void UpdateAllTargets()
    {
        foreach (var dotComp in mTargets) {
            dotComp.AddDOTSource(mPeriod, mDamage, this);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class BAOEDmgOnTimer : MonoBehaviour
{
    public uint Damage;

    private DTimer mTimer;
    private DTargetList mTargets;
    private Dictionary<int, ADamageable> mDamageables;

    // Use this for initialization
    void OnEnable()
    {
        // Timer listener:
        mTimer = GetComponent<DTimer>();
        if (mTimer) {
            mTimer.OnTimerFired.AddListener(DealDamage);
        }

        // Target listeners:
        mDamageables = new Dictionary<int, ADamageable>();
        mTargets = GetComponent<DTargetList>();
        if (mTargets) {
            mTargets.OnTargetAdded.AddListener(GetDamageable);
            mTargets.OnTargetRemoved.AddListener(RemoveDamageable);
        }
    }

    void GetDamageable(GameObject target)
    {
        if (target) {
            ADamageable damageable = target.GetComponent<ADamageable>();
            if (damageable && !mDamageables.ContainsKey(target.GetInstanceID())) {
                mDamageables.Add(target.GetInstanceID(), damageable);
            }
        }
    }

    void RemoveDamageable(GameObject target)
    {
        if (target && mDamageables.ContainsKey(target.GetInstanceID())) {
            mDamageables.Remove(target.GetInstanceID());
        }
    }

    void DealDamage()
    {
        foreach (var target in mDamageables.Values) {
            if (target != null) {
                Debug.Log(name + " DealDamage()");
                target.DealDamage(Damage);
            }
        }
    }
}

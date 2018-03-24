using System.Collections.Generic;
using UnityEngine;

public class BAOEDmgOnTimer : MonoBehaviour
{
    public uint Damage;

    [Tooltip("When this damage source will fire.")]
    public DTimer Timer;

    [Tooltip("Target data for which targets to deal damage to.")]
    public DTargetList Targets;

    private Dictionary<int, ADamageable> mDamageables;

    // Use this for initialization
    void OnEnable()
    {
        mDamageables = new Dictionary<int, ADamageable>();

        // Timer listener:
        if (!Timer)
            Timer = GetComponent<DTimer>();
        if (Timer)
            Timer.OnTimerFired.AddListener(DealDamage);

        // Target listeners:
        if (!Targets)
            Targets = GetComponent<DTargetList>();
        if (Targets) {
            Targets.OnTargetAdded.AddListener(GetDamageable);
            Targets.OnTargetRemoved.AddListener(RemoveDamageable);
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

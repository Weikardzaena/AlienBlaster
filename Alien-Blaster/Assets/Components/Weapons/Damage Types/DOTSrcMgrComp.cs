using System;
using System.Collections.Generic;
using UnityEngine;

public class DOTSrcMgrComp : MonoBehaviour
{
    private DamageableComp mDamageComp;
    private Dictionary<int, DOTApplier> mDamageSources = new Dictionary<int, DOTApplier>();

    // Use this for initialization
    void Start()
    {
        mDamageComp = GetComponent<DamageableComp>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (var dmgSource in mDamageSources.Values) {
            dmgSource.Update(Time.deltaTime);
        }
	}

    public void AddDOTSource(float period, UInt32 damage, Component instigator)
    {
        // Always overwrite source from the instigator.
        // This ensures the stats match the most recent call to this method.
        // I'm not sure how I feel about this right now, but it's what I'm going with.
        mDamageSources.Remove(instigator.GetInstanceID());
        mDamageSources.Add(instigator.GetInstanceID(), new DOTApplier(period, damage, mDamageComp));
    }

    public void RemoveDOTSource(Component instigator)
    {
        mDamageSources.Remove(instigator.GetInstanceID());
    }
}

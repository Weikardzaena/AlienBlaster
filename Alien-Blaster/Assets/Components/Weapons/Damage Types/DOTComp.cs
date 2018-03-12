using System;
using System.Collections.Generic;
using UnityEngine;

public class DOTComp : MonoBehaviour
{
    public UInt32 Damage = 1;
    public float DamagePeriod = 0.1f;

    private UInt32 mDamage;
    private float mDamagePeriod;
    private float mNextDamageTime = 0.0f;
    private List<DamageableComp> mDamageableList = new List<DamageableComp>();

    // Use this for initialization
    void Start()
    {
        mDamage = Damage;
        mDamagePeriod = DamagePeriod;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mNextDamageTime -= Time.deltaTime;

		if (mNextDamageTime < 0.0f) {
            mNextDamageTime = mDamagePeriod;

            // Ensure that we cull out all objects that are no longer valid:
            mDamageableList.RemoveAll(x => x == null);

            foreach (DamageableComp comp in mDamageableList) {
                comp.DealDamage(mDamage);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        DamageableComp otherDamageable = other.GetComponent<DamageableComp>();

        // We don't want duplicate entries in our list of things to damage:
        if (otherDamageable != null) {
            mDamageableList.Add(otherDamageable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        DamageableComp otherDamageable = other.GetComponent<DamageableComp>();
        // Always cull null before using something like List.RemoveAll():
        mDamageableList.RemoveAll(x => x == null);

        // Remove all instances of the damage component:
        if ((otherDamageable != null)) {
            mDamageableList.RemoveAll(x => x.GetInstanceID() == otherDamageable.GetInstanceID());
        }
    }
}

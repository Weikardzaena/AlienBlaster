using System;
using UnityEngine;

public class DamageableComp : MonoBehaviour
{
    private HealthComp mHealthComp;
    private DestroyableComp mDestroyableComp;

	// Use this for initialization
	void Start ()
    {
        mHealthComp = GetComponent<HealthComp>();
        mDestroyableComp = GetComponent<DestroyableComp>();
	}

    public void DealDamage(UInt32 damage)
    {
        Debug.Log(name + " DealDamage()");

        // If we have a health component, subtrace the damage from the health:
        if (mHealthComp != null) {
            UInt32 newHealth = mHealthComp.SubtractHealth(damage);
            
            // If we're at 0 health and our GameObject is destroyable, destroy self:
            if (newHealth == 0 && mDestroyableComp != null) {
                mDestroyableComp.DestroySelf();
            }
        }
    }
}

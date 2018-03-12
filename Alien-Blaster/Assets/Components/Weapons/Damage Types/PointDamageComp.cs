using System;
using UnityEngine;

public class PointDamageComp : MonoBehaviour
{
    public UInt32 DamageVal = 1;

    private UInt32 mDamage;
    private DestroyableComp mDestroyableComp;

	// Use this for initialization
	void Start ()
    {
        mDamage = DamageVal;
        mDestroyableComp = GetComponent<DestroyableComp>();
	}

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log(name + " OnCollisionEnter()");
        // There's no way of getting around checking for the Damageable Component at hit
        // since we don't know what object we're going to hit ahead of time.  And since
        // we're not going to be calling this every frame, there's no performance issue
        // (not tested, but it makes sense to think that way).
        var damageComp = col.gameObject.GetComponent<DamageableComp>();

        if (damageComp != null) {
            damageComp.DealDamage(mDamage);

            // If the hit object is damageable, destroy ourself since we want to despawn the game object.
            if (mDestroyableComp != null) {
                mDestroyableComp.DestroySelf();
            }
        }
    }
}

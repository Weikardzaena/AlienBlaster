using System;
using UnityEngine;

public class BKillOnZeroHealth : MonoBehaviour
{
    public ADestroyable DestroyableComp;

    public void HandleHealthChange(UInt32 newHealth)
    {
        if (newHealth == 0) {
            if (DestroyableComp) {
                DestroyableComp.DestroySelf();
            } else {
                Destroy(gameObject);
            }
        }
    }
}

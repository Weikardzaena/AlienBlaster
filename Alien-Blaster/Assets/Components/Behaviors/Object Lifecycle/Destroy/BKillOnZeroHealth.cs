using System;
using UnityEngine;

public class BKillOnZeroHealth : MonoBehaviour
{
    public void HandleHealthChange(UInt32 newHealth)
    {
        if (newHealth == 0) {
            Destroy(gameObject);
        }
    }
}

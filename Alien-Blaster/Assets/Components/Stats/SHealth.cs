using System;
using UnityEngine;
using UnityEngine.Events;

public class SHealth : MonoBehaviour
{
    [Serializable]
    public class HealthChange : UnityEvent<UInt32>
    { }

    public UInt32 StartHealth = 1;
    public HealthChange OnHealthChange;

    // public accessors:
    public UInt32 StartingHealth { get { return mStartHealth; } }
    public UInt32 CurrentHealth { get { return mCurHealth; } }

    private UInt32 mCurHealth;
    private UInt32 mStartHealth;

	// Use this for initialization
	void Start ()
    {
        mCurHealth = StartHealth;
        mStartHealth = StartHealth;
	}

    public UInt32 SubtractHealth(UInt32 value)
    {
        Debug.Log(name + " SubtractHealth()");
        // Check for overflow before subtracting:
        mCurHealth = value > mCurHealth ? 0 : mCurHealth - value;

        // Invoke listeners:
        OnHealthChange.Invoke(mCurHealth);

        return mCurHealth;
    }

    public UInt32 AddHealth(UInt32 value)
    {
        Debug.Log(name + " AddHealth()");
        // Check for overflow before adding:
        mCurHealth = UInt32.MaxValue - mCurHealth < value ? UInt32.MaxValue : mCurHealth + value;

        // Invoke listeners:
        OnHealthChange.Invoke(mCurHealth);

        return mCurHealth;
    }
}

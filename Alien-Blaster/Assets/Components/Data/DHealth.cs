using UnityEngine;
using UnityEngine.Events;

public class DHealth : MonoBehaviour, IResettable
{
    [System.Serializable]
    public class HealthChange : UnityEvent<uint>
    { }

    public uint StartHealth = 1;
    public HealthChange OnHealthChange;

    // public accessors:
    public uint StartingHealth { get; private set; }
    public uint CurrentHealth { get; private set; }

    // Use this for initialization
    void OnEnable()
    {
        Reset();
    }

    public uint SubtractHealth(uint value)
    {
        // Check for overflow before subtracting:
        CurrentHealth = value > CurrentHealth ? 0 : CurrentHealth - value;

        // Invoke listeners:
        OnHealthChange.Invoke(CurrentHealth );

        return CurrentHealth ;
    }

    public uint AddHealth(uint value)
    {
        // Check for overflow before adding:
        CurrentHealth = uint .MaxValue - CurrentHealth < value ? uint .MaxValue : CurrentHealth + value;

        // Invoke listeners:
        OnHealthChange.Invoke(CurrentHealth );

        return CurrentHealth ;
    }

    public void Reset()
    {
        CurrentHealth = StartHealth;
        StartingHealth = StartHealth;
    }
}

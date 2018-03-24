using UnityEngine;

public class ADamageable : MonoBehaviour
{
    public DHealth HealthComp;

    private void OnEnable()
    {
        if (!HealthComp)
            HealthComp = GetComponent<DHealth>();
    }

    public void DealDamage(uint damage)
    {
        // If we have a health component, subtract the damage from the health:
        if (HealthComp) {
            HealthComp.SubtractHealth(damage);
        }
    }
}

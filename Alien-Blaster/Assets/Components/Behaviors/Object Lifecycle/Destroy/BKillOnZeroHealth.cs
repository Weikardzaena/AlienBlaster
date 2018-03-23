using UnityEngine;

public class BKillOnZeroHealth : MonoBehaviour
{
    public ADestroyable DestroyableComp;
    public DHealth HealthComp;

    private void OnEnable()
    {
        if (HealthComp) {
            HealthComp.OnHealthChange.AddListener(HandleHealthChange);
        }
    }

    private void HandleHealthChange(uint newHealth)
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

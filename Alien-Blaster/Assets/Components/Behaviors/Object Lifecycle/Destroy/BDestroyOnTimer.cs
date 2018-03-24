using UnityEngine;

public class BDestroyOnTimer : MonoBehaviour
{
    public DSingleFireTimer Timer;
    public ADestroyable Destroyable;

    private void OnEnable()
    {
        if (!Destroyable)
            Destroyable = GetComponent<ADestroyable>();

        if (!Timer)
            Timer = GetComponent<DSingleFireTimer>();
        if (Timer)
            Timer.OnTimerFired.AddListener(Destroy);
    }

    private void Destroy()
    {
        if (Destroyable) {
            Destroyable.DestroySelf();
        }
    }
}

using UnityEngine;

public class BDestroyOnTimer : MonoBehaviour
{
    private DSingleFireTimer mTimer;
    private ADestroyable mDestroyable;
    private void OnEnable()
    {
        mDestroyable = GetComponent<ADestroyable>();

        mTimer = GetComponent<DSingleFireTimer>();
        if (mTimer) {
            mTimer.OnTimerFired.AddListener(Destroy);
        }
    }

    private void Destroy()
    {
        if (mDestroyable) {
            mDestroyable.DestroySelf();
        }
    }
}

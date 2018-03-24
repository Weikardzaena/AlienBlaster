using UnityEngine;

public class BRecycleOnTimer : MonoBehaviour
{
    private DSingleFireTimer mTimer;
    private ARecyclable mRecyclable;
    private void OnEnable()
    {
        mRecyclable = GetComponent<ARecyclable>();

        mTimer = GetComponent<DSingleFireTimer>();
        if (mTimer) {
            mTimer.OnTimerFired.AddListener(Recycle);
        }
    }

    private void Recycle()
    {
        if (mRecyclable) {
            mRecyclable.Recycle();
        }
    }
}

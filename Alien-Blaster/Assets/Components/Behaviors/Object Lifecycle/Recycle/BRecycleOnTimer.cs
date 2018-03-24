using UnityEngine;

public class BRecycleOnTimer : MonoBehaviour
{
    private DTimer mTimer;
    private ARecyclable mRecyclable;
    private void OnEnable()
    {
        mRecyclable = GetComponent<ARecyclable>();

        mTimer = GetComponent<DTimer>();
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

using UnityEngine;

public class BRecycleOnTimer : MonoBehaviour
{
    public DSingleFireTimer Timer;
    public ARecyclable RecyclableComp;

    private void OnEnable()
    {
        if (!RecyclableComp)
            RecyclableComp = GetComponent<ARecyclable>();

        if (!Timer)
            Timer = GetComponent<DSingleFireTimer>();
        if (Timer)
            Timer.OnTimerFired.AddListener(Recycle);
    }

    private void Recycle()
    {
        if (RecyclableComp) {
            RecyclableComp.Recycle();
        }
    }
}

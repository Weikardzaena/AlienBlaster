using UnityEngine;

public class BRecycleOnTrigger : MonoBehaviour
{
    private ARecyclable mRecycleComp;

    void OnEnable()
    {
        mRecycleComp = GetComponent<ARecyclable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (mRecycleComp) {
            mRecycleComp.Recycle();
        }
    }
}

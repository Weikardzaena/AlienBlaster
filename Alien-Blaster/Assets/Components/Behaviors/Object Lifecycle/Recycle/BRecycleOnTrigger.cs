using UnityEngine;

public class BRecycleOnTrigger : MonoBehaviour
{
    public ARecyclable RecycleComp;

    private void OnEnable()
    {
        if (!RecycleComp)
            RecycleComp = GetComponent<ARecyclable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (RecycleComp) {
            RecycleComp.Recycle();
        }
    }
}

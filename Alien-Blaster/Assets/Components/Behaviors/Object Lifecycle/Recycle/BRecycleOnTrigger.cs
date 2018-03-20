using UnityEngine;

public class BRecycleOnTrigger : MonoBehaviour
{
    public ARecyclable RecycleComp;

    void OnTriggerEnter(Collider other)
    {
        if (RecycleComp) {
            RecycleComp.Recycle();
        }
    }
}

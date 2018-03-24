using UnityEngine;

public class AMultipleTargets : MonoBehaviour
{
    private DTargetList mTargetList;

    private void OnEnable()
    {
        mTargetList = GetComponent<DTargetList>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " OnTriggerEnter()");
        if (mTargetList) {
            mTargetList.AddTarget(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mTargetList) {
            mTargetList.RemoveTarget(other.gameObject);
        }
    }
}

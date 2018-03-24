using UnityEngine;

public class AMultipleTargets : MonoBehaviour
{
    public DTargetList TargetList;

    private void OnEnable()
    {
        if (!TargetList)
            TargetList = GetComponent<DTargetList>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " OnTriggerEnter()");
        if (TargetList) {
            TargetList.AddTarget(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (TargetList) {
            TargetList.RemoveTarget(other.gameObject);
        }
    }
}

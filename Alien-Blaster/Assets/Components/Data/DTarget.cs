using System;
using UnityEngine;
using UnityEngine.Events;

public class DTarget : MonoBehaviour, IResettable
{
    [Serializable]
    public class TargetChanged : UnityEvent<GameObject>
    { }

    public GameObject StartTarget;
    public TargetChanged OnTargetChanged;

    public GameObject Target { get; private set; }

    public bool HasValidTarget { get { return (Target != null) && (Target.activeInHierarchy); } }

    public void SetTarget(GameObject newTarget)
    {
        Target = newTarget;
        OnTargetChanged.Invoke(Target);
    }

    public void Reset()
    {
        Target = StartTarget;
    }
}

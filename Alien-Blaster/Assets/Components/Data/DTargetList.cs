using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DTargetList : MonoBehaviour, IResettable
{
    [Serializable]
    public class TargetAdded : UnityEvent<GameObject>
    { }

    [Serializable]
    public class TargetRemoved : UnityEvent<GameObject>
    { }

    public List<GameObject> StartingTargets;
    public TargetAdded OnTargetAdded;
    public TargetRemoved OnTargetRemoved;

    public IList<GameObject> Targets { get { return new List<GameObject>(mTargets.Values); } }

    private Dictionary<int, GameObject> mTargets;

    private void OnEnable()
    {
        Reset();
    }

    public void AddTarget(GameObject target)
    {
        if (target) {
            if (!mTargets.ContainsKey(target.GetInstanceID())) {
                mTargets.Add(target.GetInstanceID(), target);
                OnTargetAdded.Invoke(target);
            }
        }
    }

    public void RemoveTarget(GameObject target)
    {
        if (target) {
            if (mTargets.ContainsKey(target.GetInstanceID())) {
                mTargets.Remove(target.GetInstanceID());
                OnTargetRemoved.Invoke(target);
            }
        }
    }

    public void Reset()
    {
        mTargets = new Dictionary<int, GameObject>();
        if (StartingTargets != null) {
            foreach (var target in StartingTargets.Where(x => x != null)) {
                AddTarget(target);
            }
        }
    }
}

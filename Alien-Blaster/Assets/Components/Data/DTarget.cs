using UnityEngine;

public class DTarget : MonoBehaviour, IResettable
{
    public GameObject Target;

    public bool HasValidTarget()
    {
        return (Target != null) && (Target.activeInHierarchy);
    }

    public void Reset()
    {
        Target = null;
    }
}

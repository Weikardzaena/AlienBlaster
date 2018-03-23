using System.Collections.Generic;
using UnityEngine;

public class ARecyclable : MonoBehaviour
{
    private List<IResettable> mResettableComponents;

    private void OnEnable()
    {
        mResettableComponents = new List<IResettable>(GetComponents<IResettable>());
    }
    public void Recycle()
    {
        foreach (var comp in mResettableComponents) {
            var resettable = comp as IResettable;

            if (resettable != null)
                resettable.Reset();
        }

        gameObject.SetActive(false);
    }
}

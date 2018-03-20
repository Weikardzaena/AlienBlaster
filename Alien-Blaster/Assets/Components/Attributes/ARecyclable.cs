﻿using UnityEngine;

public class ARecyclable : MonoBehaviour
{
    private IResettable[] mComponents;

    // Use this for initialization
    void OnEnable()
    {
        mComponents = GetComponents<IResettable>();
    }

    public void Recycle()
    {
        foreach (IResettable comp in mComponents) {
            comp.Reset();
        }

        gameObject.SetActive(false);
    }
}

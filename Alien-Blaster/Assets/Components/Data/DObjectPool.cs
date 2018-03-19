using System;
using System.Collections.Generic;
using UnityEngine;

public class DObjectPool : MonoBehaviour
{
    [Tooltip("The prefab of the object that this pool will contain.")]
    public GameObject ObjectPrefab;

    [Tooltip("How many objects this pool will contain at start.")]
    public UInt16 InitialQuantity = 10;

    [Tooltip("Should this pool create new instances of the prefab if none are available?")]
    public bool ShouldExpand = true;

    private List<GameObject> mObjectPool;

    // Use this for initialization
    void Start()
    {
        for (UInt16 i = 0; i < InitialQuantity; i++) {
            mObjectPool.Add(Instantiate(ObjectPrefab));
        }
    }

    public GameObject GetObject()
    {
        for (UInt16 i = 0; i < mObjectPool.Count; i++) {
            if (!mObjectPool[i].activeInHierarchy) {
                return mObjectPool[i];
            }
        }

        if (ShouldExpand) {
            GameObject newObj = Instantiate(ObjectPrefab);
            return newObj;
        }

        return null;
    }
}
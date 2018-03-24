using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolMgr : MonoBehaviour, IResettable
{
    public List<DObjectPool> ObjectPoolPrefabs;

    private List<DObjectPool> mObjectPools;

    private void OnEnable()
    {
        Reset();
    }
    public DObjectPool GetObjectPool(FirableType firableType)
    {
        return mObjectPools.FirstOrDefault(x => (x != null) &&
                                                (firableType == x.FirableType));
    }

    public void Reset()
    {
        mObjectPools = new List<DObjectPool>();
        foreach (var objPool in ObjectPoolPrefabs) {
            if (objPool) {
                mObjectPools.Add(Instantiate(objPool));
            }
        }
    }
}

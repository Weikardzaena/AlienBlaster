using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolMgr : MonoBehaviour
{
    public List<DObjectPool> ObjectPoolPrefabs;

    private List<DObjectPool> mObjectPools;
    private void OnEnable()
    {
        mObjectPools = new List<DObjectPool>();
        foreach (var objPool in ObjectPoolPrefabs) {
            if (objPool) {
                mObjectPools.Add(Instantiate(objPool));
            }
        }
    }
    public DObjectPool GetObjectPool(FirableType firableType)
    {
        return mObjectPools.FirstOrDefault(x => (x != null) &&
                                                (firableType == x.FirableType));
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolMgr : MonoBehaviour
{
    public List<DObjectPool> ObjectPools;

    public DObjectPool GetObjectPool(FirableType firableType)
    {
        if (ObjectPools != null) {
            return ObjectPools.FirstOrDefault(x => (x != null) &&
                                                   (firableType == x.FirableType));
        }

        return null;
    }
}

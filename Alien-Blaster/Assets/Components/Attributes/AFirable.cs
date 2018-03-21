using UnityEngine;

public class AFirable : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public FirableType FirableType;

    private DObjectPool mObjPool;

    // Use this for initialization
    void Start()
    {
        var objPoolMgr = FindObjectOfType<ObjectPoolMgr>();
        if (objPoolMgr) {
            mObjPool = objPoolMgr.GetObjectPool(FirableType);
        }
    }

    public void Fire()
    {
        if (mObjPool) {
            foreach (var spawn in SpawnPoints) {
                var gameObj = mObjPool.GetObject();

                if (gameObj) {
                    var objTrans = gameObj.transform;

                    if (objTrans) {
                        objTrans.position = spawn.position;
                        objTrans.rotation = spawn.rotation;
                    }

                    gameObj.SetActive(true);
                }
            }
        }
    }
}

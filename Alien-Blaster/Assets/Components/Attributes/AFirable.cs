using UnityEngine;

public class AFirable : MonoBehaviour
{
    public Transform[] SpawnPoints;

    private DObjectPool mObjPool;

    // Use this for initialization
    void Start()
    {
        var objPool = GameObject.FindGameObjectWithTag(tag);
        if (objPool) {
            mObjPool = objPool.GetComponent<DObjectPool>();
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

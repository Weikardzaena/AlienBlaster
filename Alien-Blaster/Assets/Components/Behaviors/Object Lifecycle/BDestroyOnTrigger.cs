using UnityEngine;

public class BDestroyOnTrigger : MonoBehaviour
{
    private ADestroyable mDestroyableComp;

    // Use this for initialization
    void Start()
    {
        mDestroyableComp = gameObject.GetComponent<ADestroyable>();
    }
	
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + "DestroyOnTriggerComp::OnTriggerEnter()");

        if (mDestroyableComp) {
            mDestroyableComp.DestroySelf();
        } else {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class DestroyOnTriggerComp : MonoBehaviour
{
    private DestroyableComp mDestroyableComp;

	// Use this for initialization
	void Start () {
        mDestroyableComp = gameObject.GetComponent<DestroyableComp>();
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

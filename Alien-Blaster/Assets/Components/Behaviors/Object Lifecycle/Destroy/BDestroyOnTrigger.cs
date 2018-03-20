using UnityEngine;

public class BDestroyOnTrigger : MonoBehaviour
{
    public ADestroyable DestroyableComp;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + "DestroyOnTriggerComp::OnTriggerEnter()");

        if (DestroyableComp) {
            DestroyableComp.DestroySelf();
        } else {
            Destroy(gameObject);
        }
    }
}

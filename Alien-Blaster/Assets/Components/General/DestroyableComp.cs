using UnityEngine;

public class DestroyableComp : MonoBehaviour
{
    public void DestroySelf()
    {
        Debug.Log(name + " was destroyed!");

        // Destroy self:
        Destroy(gameObject);
    }
}

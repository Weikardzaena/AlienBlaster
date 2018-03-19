using UnityEngine;

public class ADestroyable : MonoBehaviour
{
    public void DestroySelf()
    {
        Debug.Log(name + " was destroyed!");

        // Destroy self:
        Destroy(gameObject);
    }
}

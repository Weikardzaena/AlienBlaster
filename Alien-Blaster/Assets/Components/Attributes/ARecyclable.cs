using UnityEngine;

public class ARecyclable : MonoBehaviour
{
    public Component[] ResettableComponents;

    public void Recycle()
    {
        foreach (IResettable comp in ResettableComponents) {
            comp.Reset();
        }

        gameObject.SetActive(false);
    }
}

using UnityEngine;

public class ARecyclable : MonoBehaviour
{
    public Component[] ResettableComponents;

    public void Recycle()
    {
        foreach (var comp in ResettableComponents) {
            var resettable = comp as IResettable;

            if (resettable != null)
                resettable.Reset();
        }

        gameObject.SetActive(false);
    }
}

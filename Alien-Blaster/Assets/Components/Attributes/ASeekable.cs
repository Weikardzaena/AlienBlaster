using UnityEngine;

public class ASeekable : MonoBehaviour
{
    public DObjectElapsedTime ObjectElapsedTime;

    private void OnEnable()
    {
        if (!ObjectElapsedTime)
            ObjectElapsedTime = GetComponent<DObjectElapsedTime>();
    }

    public void StartRewind(float seconds, float duration)
    {
        if (ObjectElapsedTime)
            StartCoroutine(ObjectElapsedTime.Rewind(seconds, duration));
    }

    public void StartFastForward(float seconds, float duration)
    {
        if (ObjectElapsedTime)
            StartCoroutine(ObjectElapsedTime.FastForward(seconds, duration));
    }
}

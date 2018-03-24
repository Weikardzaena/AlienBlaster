using System.Collections;
using UnityEngine;

public class DObjectElapsedTime : MonoBehaviour, IResettable
{
    public float ElapsedTime { get; private set; }

    private bool mIsSeeking;

    private void OnEnable()
    {
        Reset();
    }

    private void Update()
    {
        if (!mIsSeeking)
            ElapsedTime += Time.deltaTime;
    }

    public IEnumerator Rewind(float seconds, float duration)
    {
        if (!mIsSeeking) {
            mIsSeeking = true;

            for (float i = 0.0f; i < duration; i += Time.deltaTime) {
                ElapsedTime -= Time.deltaTime / duration * seconds;
                yield return null;
            }

            mIsSeeking = false;
        }
    }

    public IEnumerator FastForward(float seconds, float duration)
    {
        if (!mIsSeeking) {
            mIsSeeking = true;

            for (float i = 0.0f; i < duration; i += Time.deltaTime) {
                ElapsedTime += Time.deltaTime / duration * seconds;
                yield return null;
            }

            mIsSeeking = false;
        }
    }

    public void Reset()
    {
        ElapsedTime = 0.0f;
        mIsSeeking = false;
    }
}

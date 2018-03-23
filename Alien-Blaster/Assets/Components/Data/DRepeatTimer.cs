using System;
using UnityEngine;
using UnityEngine.Events;

public class DRepeatTimer : MonoBehaviour, IResettable
{
    [Serializable]
    public class TimerFired : UnityEvent
    { }

    public float Duration = 1.0f;
    public TimerFired OnTimerFired;

    private float mTimeRemaining = 0.0f;

    // Use this for initialization
    void OnEnable()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        mTimeRemaining -= Time.deltaTime;
        if (mTimeRemaining < 0.0f) {
            // Do cleanup first because Invoked methods might change the state.
            Reset();
            OnTimerFired.Invoke();
        }
    }

    public void Reset()
    {
        mTimeRemaining = Duration;
    }
}

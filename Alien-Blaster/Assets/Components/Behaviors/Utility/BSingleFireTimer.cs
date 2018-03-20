using System;
using UnityEngine;
using UnityEngine.Events;

public class BSingleFireTimer : MonoBehaviour, IResettable
{
    [Serializable]
    public class TimerExpired : UnityEvent
    { }

    public float Duration = 1.0f;
    public TimerExpired OnTimerExpired;

    public bool IsFinished { get; private set; }

    private float mTimeRemaining;

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsFinished) {
            mTimeRemaining -= Time.deltaTime;

            if (mTimeRemaining < 0.0f) {
                // Make sure to set IsFinished first because Reset is called via Recyclable later on.
                IsFinished = true;
                OnTimerExpired.Invoke();
            }
        }
    }

    public void Reset()
    {
        mTimeRemaining = Duration;
        IsFinished = false;
    }
}

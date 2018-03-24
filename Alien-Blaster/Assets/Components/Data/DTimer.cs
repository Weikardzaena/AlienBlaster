using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class DTimer : MonoBehaviour, IResettable
{
    [Serializable]
    public class TimerFired : UnityEvent
    { }

    public float Duration = 1.0f;
    public TimerFired OnTimerFired;

    protected float mTimeRemaining;

    private void OnEnable()
    {
        Reset();
    }

    private void Update()
    {
        UpdateTime(Time.deltaTime);
    }

    protected abstract void UpdateTime(float deltaTime);

    public virtual void Reset()
    {
        mTimeRemaining = Duration;
    }
}

public class DRepeatTimer : DTimer
{
    // Update is called once per frame
    protected override void UpdateTime(float deltaTime)
    {
        mTimeRemaining -= deltaTime;
        if (mTimeRemaining < 0.0f) {
            // Do cleanup first because Invoked methods might change the state.
            Reset();
            OnTimerFired.Invoke();
        }
    }
}

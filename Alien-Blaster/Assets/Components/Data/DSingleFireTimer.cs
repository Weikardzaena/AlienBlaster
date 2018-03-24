public class DSingleFireTimer : DTimer
{
    public bool IsFinished { get; private set; }

    // Update is called once per frame
    protected override void UpdateTime(float deltaTime)
    {
        if (!IsFinished) {
            mTimeRemaining -= deltaTime;

            if (mTimeRemaining < 0.0f) {
                // Make sure to set IsFinished first because Reset is called via Recyclable later on.
                IsFinished = true;
                OnTimerFired.Invoke();
            }
        }
    }

    public override void Reset()
    {
        base.Reset();
        IsFinished = false;
    }
}

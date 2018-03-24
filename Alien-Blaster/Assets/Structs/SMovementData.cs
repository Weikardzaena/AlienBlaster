using UnityEngine;

public class SMovementData
{
    public float DeltaTime { get; private set; }
    public float ElapsedTime { get; private set; }
    public Transform Transform { get; private set; }

    public SMovementData(Transform transform)
    {
        ElapsedTime = 0.0f;
        DeltaTime = 0.0f;
        Transform = transform;
    }

    public void AddDelta(float deltaTime)
    {
        DeltaTime = deltaTime;
        ElapsedTime += deltaTime;
    }
}

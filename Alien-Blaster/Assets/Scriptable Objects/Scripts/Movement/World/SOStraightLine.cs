using UnityEngine;

[CreateAssetMenu(menuName = "Scripted Movement/World/Straight Line")]
public class SOStraightLine : SOWorldMovement
{
    [Range(0.0f, 360.0f)]
    public float Angle = 0.0f;
    public float Speed = 1.0f;

    const float DEG_TO_RAD = Mathf.PI / 180.0f;
    public override void ApplyTransform(SMovementData movementData)
    {
        if (float.IsNaN(Angle) || float.IsNaN(Speed))
            return;

        if (movementData.Transform && movementData.Transform.parent) {
            movementData.Transform.parent.Translate(new Vector3(
                Mathf.Cos(Angle * DEG_TO_RAD) * movementData.DeltaTime * Speed,
                0.0f,
                Mathf.Sin(Angle * DEG_TO_RAD) * movementData.DeltaTime * Speed));
        }
    }
}

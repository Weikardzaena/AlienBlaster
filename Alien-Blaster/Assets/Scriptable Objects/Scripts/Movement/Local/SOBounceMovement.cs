using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripted Movement/Local/Bounce")]
public class SOBounceMovement : SOLocalMovement
{
    [Range(0.0f, 180.0f)]
    public float Orientation = 0.0f;

    public float Period = 1.0f;
    public float Distance = 1.0f;

    const float DEG_TO_RAD = Mathf.PI / 180.0f;

    public override void ApplyTransform(SMovementData movementData)
    {
        if (movementData.Transform) {
            float periodPercent = movementData.ElapsedTime / Period - (float)Math.Truncate(movementData.ElapsedTime / Period);

            if (float.IsNaN(Distance) ||
                float.IsNaN(Period) ||
                float.IsNaN(Orientation) ||
                float.IsNaN(periodPercent) ||
                float.IsInfinity(periodPercent))
                return;

            if (periodPercent < 0.5) {
                float negativePathVal = Distance - 4 * Distance * periodPercent;
                movementData.Transform.localPosition = new Vector3(
                    negativePathVal * Mathf.Cos(DEG_TO_RAD * Orientation),
                    movementData.Transform.localPosition.y,
                    negativePathVal * Mathf.Sin(DEG_TO_RAD * Orientation));
            } else {
                float positivePathVal = 4 * Distance * periodPercent - 3 * Distance;
                movementData.Transform.localPosition = new Vector3(
                    positivePathVal * Mathf.Cos(DEG_TO_RAD * Orientation),
                    movementData.Transform.localPosition.y,
                    positivePathVal * Mathf.Sin(DEG_TO_RAD * Orientation));
            }
        }
    }
}

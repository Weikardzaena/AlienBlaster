using UnityEngine;

[CreateAssetMenu(menuName = "Scripted Movement/Local/Spring")]
public class SOSpringMovement : SOLocalMovement
{
    [Range(0.0f, 180.0f)]
    public float Orientation = 0.0f;

    public float Period = 1.0f;
    public float Distance = 1.0f;

    const float DEG_TO_RAD = Mathf.PI / 180.0f;
    public override void ApplyTransform(SMovementData movementData)
    {
        if (float.IsNaN(Orientation) ||
            float.IsNaN(Period) ||
            float.IsNaN(Distance))
            return;

        if (movementData.Transform) {
            float orientation = Orientation * DEG_TO_RAD;
            float timeArg = movementData.ElapsedTime / Period;
            movementData.Transform.localPosition = new Vector3(
                Distance * Mathf.Cos(orientation) * Mathf.Cos(timeArg),
                movementData.Transform.localPosition.y,
                Distance * Mathf.Sin(orientation) * Mathf.Cos(timeArg));
        }
    }
}

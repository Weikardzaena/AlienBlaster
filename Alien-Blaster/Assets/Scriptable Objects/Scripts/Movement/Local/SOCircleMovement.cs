using UnityEngine;

[CreateAssetMenu(menuName = "Scripted Movement/Local/Circular Movement")]
public class SOCircleMovement : SOLocalMovement
{
    public float Radius = 1.0f;
    public float AngularFrequency = 1.0f;
    public bool ShouldTurn = true;
    public bool ReverseDirection = false;

    const float RAD_TO_DEG = 180.0f / Mathf.PI;

    public override void ApplyTransform(SMovementData movementData)
    {
        if (float.IsNaN(Radius) ||
            float.IsNaN(AngularFrequency))
            return;

        if (movementData.Transform) {
            float timeArg = AngularFrequency * movementData.ElapsedTime;
            if (ReverseDirection)
                timeArg *= -1;

            movementData.Transform.localPosition = new Vector3(
                Radius * Mathf.Cos(timeArg),
                movementData.Transform.localPosition.y,
                -Radius * Mathf.Sin(timeArg));

            if (ShouldTurn) {
                movementData.Transform.localRotation = Quaternion.AngleAxis(
                    timeArg * RAD_TO_DEG,
                    Vector3.up);
            }
        }
    }
}

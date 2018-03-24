using UnityEngine;

[CreateAssetMenu(menuName = "Scripted Movement/Local/Figure Eight")]
public class SOFigureEight : SOLocalMovement
{
    public float Period = 1.0f;
    public float LongAxis = 1.0f;
    public float ShortAxis = 1.0f;

    public bool Horizontal = true;
    public bool ReverseDirection = false;
    private bool ShouldTurn = false; // For now, we're going to hide this since it's not working as intended

    const float RAD_TO_DEG = 180 / Mathf.PI;

    public override void ApplyTransform(SMovementData movementData)
    {
        if (float.IsNaN(Period) ||
            float.IsNaN(LongAxis) ||
            float.IsNaN(ShortAxis))
            return;

        if (movementData.Transform) {
            float timeArg = movementData.ElapsedTime / Period;

            if (ReverseDirection)
                timeArg *= -1;

            float longAxisPos = LongAxis * Mathf.Sin(timeArg);
            float shortAxisPos = ShortAxis * Mathf.Sin(2 * timeArg);

            if (Horizontal) {
                movementData.Transform.localPosition = new Vector3(
                    longAxisPos, // long axis is X for horizontal orientation
                    movementData.Transform.localPosition.y,
                    shortAxisPos); // short axis is Z for horizontal orientation

                // TODO:  This doesn't work, but I'm leaving it alone because I can fix it later.
                if (ShouldTurn) {
                    movementData.Transform.rotation = Quaternion.AngleAxis(
                        RAD_TO_DEG * timeArg,
                        Vector3.up);
                }
            }
            else {
                movementData.Transform.localPosition = new Vector3(
                    shortAxisPos, // short axis is X for vertical orientation
                    movementData.Transform.localPosition.y,
                    longAxisPos); // long axis is Z for vertical orientation

                // TODO:  This doesn't work, but I'm leaving it alone because I can fix it later.
                if (ShouldTurn) {
                    movementData.Transform.rotation = Quaternion.AngleAxis(
                        RAD_TO_DEG * timeArg,
                        Vector3.up);
                }
            }
        }
    }
}

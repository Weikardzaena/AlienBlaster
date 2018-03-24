using UnityEngine;

public abstract class SOScriptedMovement : ScriptableObject
{
    public abstract void ApplyTransform(SMovementData movementData);
}

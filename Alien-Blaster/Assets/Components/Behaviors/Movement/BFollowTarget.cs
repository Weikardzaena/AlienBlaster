﻿using UnityEngine;

public class BFollowTarget : MonoBehaviour
{
    [Tooltip("If enabled, the game object will turn at the specified rate.  Note that if the rate is too low, it could miss the target.")]
    public bool SmoothTurn = false;

    [Tooltip("How quickly the component will turn toward the target.  Only used if SmoothTurn is on.")]
    public float TurnSpeed = 1.0f;

    [Tooltip("How fast the object will move toward the target.")]
    public float MoveSpeed = 1.0f;

    [Tooltip("Which component will be the source of the tracking.")]
    public DTarget TargetData;

    private void OnEnable()
    {
        if (TargetData == null)
            TargetData = GetComponent<DTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetData && TargetData.HasValidTarget) {
            // Look at target:
            if (SmoothTurn) {
                var targetRot = Quaternion.LookRotation(TargetData.Target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, TurnSpeed * Time.deltaTime);
            } else {
                transform.LookAt(TargetData.Target.transform);
            }
        }

        // Move forward:
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtComp : MonoBehaviour
{
    public bool SmoothTurn = false;
    public float TurnSpeed = 1.0f;
    public GameObject Target;

    // Update is called once per frame
    void Update()
    {
        if (Target != null) {
            if (SmoothTurn) {
                var targetRot = Quaternion.LookRotation(Target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, TurnSpeed * Time.deltaTime);
            } else {
                transform.LookAt(Target.transform);
            }
        }
    }	
}

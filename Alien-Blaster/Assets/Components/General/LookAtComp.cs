using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtComp : MonoBehaviour
{
    public float TurnSpeed = 1.0f;
    public GameObject mTarget;

    private float mTurnSpeed;

    // Use this for initialization
    void Start()
    {
        mTurnSpeed = TurnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (mTarget != null) {
            var targetRot = Quaternion.LookRotation(mTarget.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, mTurnSpeed * Time.deltaTime);
        }
    }	

    public void SetTarget(GameObject newTarget)
    {
        mTarget = newTarget;
    }
}

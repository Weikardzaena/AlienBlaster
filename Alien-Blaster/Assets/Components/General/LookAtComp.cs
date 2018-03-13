using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtComp : MonoBehaviour
{
    public float TurnSpeed;
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
            transform.LookAt(mTarget.transform);
        }
    }	

    public void SetTarget(GameObject newTarget)
    {
        mTarget = newTarget;
    }
}

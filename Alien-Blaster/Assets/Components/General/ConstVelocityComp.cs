using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstVelocityComp : MonoBehaviour
{
    [Tooltip("How fast the object moves in m/s.")]
    public float Speed = 1.0f;
    [Tooltip("The direction the object will move (relative, not global direction).  Will be normalized on init.")]
    public Vector3 Direction = new Vector3(0, 0, 0);

    private float mSpeed;
    private Vector3 mDirection;

	// Use this for initialization
	void Start ()
    {
        mDirection = Direction.normalized;
        mSpeed = Speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(mDirection * mSpeed * Time.deltaTime);
	}
}

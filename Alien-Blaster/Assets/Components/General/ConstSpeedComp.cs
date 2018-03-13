using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstSpeedComp : MonoBehaviour
{
    [Tooltip("How fast the object moves in m/s.")]
    public float Speed = 1.0f;

    private float mSpeed;

	// Use this for initialization
	void Start ()
    {
        mSpeed = Speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MaxSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizDelta = Input.GetAxis("Horizontal") * Time.deltaTime * MaxSpeed;
        float vertDelta = Input.GetAxis("Vertical") * Time.deltaTime * MaxSpeed;

        transform.Translate(horizDelta, vertDelta, 0.0f);
	}
}

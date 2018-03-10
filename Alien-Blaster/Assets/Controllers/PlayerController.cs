using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MaxSpeed = 10.0f;
    public float AutoFirePeriod = 0.75f;

    private float mNextFireTime = 0.0f;

	// Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    void Update ()
    {
        // Reset the fire time when the fire button is released:
        if (Input.GetButtonUp("Fire1")) {
            mNextFireTime = 0.0f;
        }

        // If the fire button is down, check if it's time to fire again:
        if (Input.GetButton("Fire1")) {
            mNextFireTime -= Time.deltaTime;

            // The fire period has expired, so fire and reset the timer:
            if (mNextFireTime < 0.0f) {
                Fire();
                mNextFireTime = AutoFirePeriod;
            }
        }

        // Move:
        float horizDelta = Input.GetAxis("Horizontal") * Time.deltaTime * MaxSpeed;
        float vertDelta = Input.GetAxis("Vertical") * Time.deltaTime * MaxSpeed;

        transform.Translate(horizDelta, vertDelta, 0.0f);
	}

    private void Fire()
    {
        Debug.Log("Fire!");
    }
}

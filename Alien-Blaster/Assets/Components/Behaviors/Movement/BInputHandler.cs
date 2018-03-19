using UnityEngine;

public class BInputHandler : MonoBehaviour {

    public float MaxSpeed = 10.0f;
    public float AutoFirePeriod = 0.75f;

    private float mNextFireTime = 0.0f;

    // Update is called once per frame
    void Update()
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

        // Handle super pressed:
        if (Input.GetButtonDown("Super")) {
            FireSuper();
        }

        // Move:
        Vector3 forwardDelta = Input.GetAxis("Vertical") * Time.deltaTime * MaxSpeed * Vector3.forward;
        Vector3 rightDelta = Input.GetAxis("Horizontal") * Time.deltaTime * MaxSpeed * Vector3.right;

        transform.Translate(forwardDelta + rightDelta);
    }

    private void Fire()
    {
        Debug.Log("Fire!");
    }

    private void FireSuper()
    {
        Debug.Log("Super!");
    }
}

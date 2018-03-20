using System.Collections.Generic;
using UnityEngine;

public class BInputHandler : MonoBehaviour {

    public float MaxSpeed = 10.0f;
    public float AutoFirePeriod = 0.75f;
    public GameObject[] StartWeapons;

    private float mNextFireTime = 0.0f;
    private List<AFirable> mWeapons = new List<AFirable>();

    void Start()
    {
        foreach (var weapon in StartWeapons) {
            var instance = Instantiate(weapon, transform);
            var firable = instance.GetComponent<AFirable>();
            if (firable) {
                mWeapons.Add(firable);
            }
        }
    }

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

    public void AddWeapon(AFirable weapon)
    {
        if (weapon) {
            mWeapons.Add(weapon);
        }
    }

    private void Fire()
    {
        foreach (var weapon in mWeapons) {
            weapon.Fire();
        }
    }

    private void FireSuper()
    {
        Debug.Log("Super!");
    }
}

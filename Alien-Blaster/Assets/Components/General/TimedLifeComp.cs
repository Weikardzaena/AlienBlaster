using UnityEngine;

public class TimedLifeComp : MonoBehaviour
{
    public float Lifetime = 1.0f;

    private float mTimeRemaining;
    private DestroyableComp mDestroyableComp;

	// Use this for initialization
	void Start () {
        mDestroyableComp = gameObject.GetComponent<DestroyableComp>();
        mTimeRemaining = Lifetime;
	}
	
	// Update is called once per frame
	void Update () {
        mTimeRemaining -= Time.deltaTime;

        if (mTimeRemaining < 0.0f) {
            if (mDestroyableComp) {
                mDestroyableComp.DestroySelf();
            } else {
                Destroy(gameObject);
            }
        }
	}
}

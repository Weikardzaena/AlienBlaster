using UnityEngine;

public class BConstVelocity : MonoBehaviour
{
    [Tooltip("How fast the object moves in m/s.")]
    public float Speed = 1.0f;
    [Tooltip("Relative direction the object moves (will be normalized).  Do not set this directly at runtime.  Use SetRelativeDirection().")]
    public Vector3 RelativeDirection = new Vector3(0.0f, 0.0f, 1.0f);

    private Vector3 mNormalizedDir;

    // Use this for initialization
    void OnEnable()
    {
        mNormalizedDir = RelativeDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(mNormalizedDir * Speed * Time.deltaTime);
    }

    public void SetRelativeDirection(Vector3 newDir)
    {
        RelativeDirection = newDir.normalized;
        mNormalizedDir = RelativeDirection;
    }
}

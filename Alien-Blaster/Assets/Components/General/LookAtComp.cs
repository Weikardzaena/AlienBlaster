using UnityEngine;

public class LookAtComp : MonoBehaviour
{
    [Tooltip("Whether the look should snap to the target or smoothly look at it.")]
    public bool SmoothTurn = false;

    [Tooltip("How quickly the component will turn toward the target.  Only used if SmoothTurn is on.")]
    public float TurnSpeed = 1.0f;

    [Tooltip("The game object to look at.")]
    public GameObject Target;

    // Update is called once per frame
    void Update()
    {
        if (Target != null) {
            if (SmoothTurn) {
                var targetRot = Quaternion.LookRotation(Target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, TurnSpeed * Time.deltaTime);
            } else {
                transform.LookAt(Target.transform);
            }
        }
    }	
}

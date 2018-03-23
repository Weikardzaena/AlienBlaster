using UnityEngine;

public class AAutoAcquiresNearestEnemy : MonoBehaviour
{
    public DTarget TargetData;

    private bool mHasValidTarget = false;

    // Use this for initialization
    void Start()
    {
        mHasValidTarget = AcquireNearestEnemy();
    }

    void Update()
    {
        if (!mHasValidTarget) {
            mHasValidTarget = AcquireNearestEnemy();
        }
        else {
            mHasValidTarget = (TargetData) && (TargetData.HasValidTarget());
        }
    }

    /// <summary>
    /// If no current target exists, find the closest enemy and store it.
    /// </summary>
    /// <returns>True if a valid target was found; false otherwise.</returns>
    private bool AcquireNearestEnemy()
    {
        if (TargetData) {
            if (TargetData.HasValidTarget())
                // We already have a target.
                return true;

            // local variables:
            float closestDist = float.MaxValue;
            var enemies = FindObjectsOfType<BEnemyMovement>();
            var ourPos = transform.position;

            if (enemies.Length > 0) {
                // Always grab the first enemy in the array as default:
                TargetData.Target = enemies[0].gameObject;
                closestDist = (enemies[0].transform.position - ourPos).sqrMagnitude;

                if (enemies.Length > 1) {
                    for (uint i = 1; i < enemies.Length; i++) {
                        float otherDist = (enemies[i].transform.position - ourPos).sqrMagnitude;
                        if (otherDist < closestDist) {
                            closestDist = otherDist;
                            TargetData.Target = enemies[i].gameObject;
                        }
                    }
                }

                // Since we grabbed the first enemy in the array by default, we are guaranteed to have a target here.
                return true;
            }
        }

        // No Target was stored.  Return false.
        return false;
    }
}

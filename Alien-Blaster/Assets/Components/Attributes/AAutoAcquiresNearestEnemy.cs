using UnityEngine;

public class AAutoAcquiresNearestEnemy : MonoBehaviour
{
    private bool mHasValidTarget = false;
    private DTarget mTargetData;

    // Use this for initialization
    void OnEnable()
    {
        mTargetData = GetComponent<DTarget>();
        mHasValidTarget = AcquireNearestEnemy();
    }

    void Update()
    {
        if (!mHasValidTarget) {
            mHasValidTarget = AcquireNearestEnemy();
        }
        else {
            mHasValidTarget = (mTargetData) && (mTargetData.HasValidTarget);
        }
    }

    /// <summary>
    /// If no current target exists, find the closest enemy and store it.
    /// </summary>
    /// <returns>True if a valid target was found; false otherwise.</returns>
    private bool AcquireNearestEnemy()
    {
        if (mTargetData) {
            if (mTargetData.HasValidTarget)
                // We already have a target.
                return true;

            // local variables:
            float closestDist = float.MaxValue;
            var enemies = FindObjectsOfType<BEnemyMovement>();
            var ourPos = transform.position;
            GameObject closestTarget;

            if (enemies.Length > 0) {
                // Always grab the first enemy in the array as default:
                closestTarget = enemies[0].gameObject;
                closestDist = (enemies[0].transform.position - ourPos).sqrMagnitude;

                if (enemies.Length > 1) {
                    for (uint i = 1; i < enemies.Length; i++) {
                        float otherDist = (enemies[i].transform.position - ourPos).sqrMagnitude;
                        if (otherDist < closestDist) {
                            closestDist = otherDist;
                            closestTarget = enemies[i].gameObject;
                        }
                    }
                }

                // Since we grabbed the first enemy in the array by default, we are guaranteed to have a target here.
                mTargetData.SetTarget(closestTarget);
                return true;
            }
        }

        // No Target was stored.  Return false.
        return false;
    }
}

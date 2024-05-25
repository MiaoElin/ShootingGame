using UnityEngine;

public static class PureFuction {

    public static bool IsPointInRange(Vector3 center, Vector3 pos, float range, out float distance) {
        distance = Vector3.SqrMagnitude(center - pos);
        if (distance <= range * range) {
            return true;
        } else {
            return false;
        }
    }

    public static bool IsPointInRange(Vector3 center, Vector3 pos, float range) {
        var distance = Vector3.SqrMagnitude(center - pos);
        if (distance <= range * range) {
            return true;
        } else {
            return false;
        }
    }

    public static bool IsInclueAngle(Vector3 target, float angleMin, float angleMax) {
        float angle = Vector3.SignedAngle(Vector3.forward, target, Vector3.up);
        Debug.Log(angle);
        if (angle >= angleMin && angle <= angleMax) {
            return true;
        } else {
            return false;
        }
    }

}
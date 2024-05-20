using UnityEngine;

public static class PureFuction {

    public static bool IsPointInRange(Vector3 center, Vector3 pos, int range, out float distance) {
        distance = Vector3.SqrMagnitude(center - pos);
        if (distance <= range * range) {
            return true;
        } else {
            return false;
        }
    }

}
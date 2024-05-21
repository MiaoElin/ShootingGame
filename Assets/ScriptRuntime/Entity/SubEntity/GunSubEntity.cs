using UnityEngine;

public class GunSubEntity : MonoBehaviour {
    public int typeID;
    [SerializeField] Transform gunObj;
    [SerializeField] Transform launchPoint;
    [SerializeField] Transform crossHair;
    public int damage;
    public int bulletCount;
    public int bulletCountMax;

    public GunSubEntity() {
    }

    public void SetCrossHair(Vector3 worldPos) {
        crossHair.position = worldPos;
    }
}
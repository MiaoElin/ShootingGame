using UnityEngine;

public class GunSubEntity : MonoBehaviour {
    public int typeID;
    public float shootRang;
    [SerializeField] Transform modTransform;
    [SerializeField] public Transform launchPoint;
    [SerializeField] Transform crossHair;
    public int bulletTypeID;
    public int bulletCount;
    public int bulletCountMax;

    public GunSubEntity() {
    }

    public void SetCrossHair(Vector3 worldPos) {
        crossHair.position = worldPos;
    }
}
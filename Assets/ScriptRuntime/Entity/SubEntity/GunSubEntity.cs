using UnityEngine;

public class GunSubEntity : MonoBehaviour {
    public int typeID;
    [SerializeField] Transform gunObj;
    public Transform launchPoint;
    public int damage;
    public int bulletCount;
    public int bulletCountMax;

    public GunSubEntity(){
    }
}
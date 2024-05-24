using UnityEngine;

[CreateAssetMenu(menuName = "TM/TM_Bullet", fileName = "TM_Bullet_")]
public class BulletTM : ScriptableObject {
    public int typeID;
    public int damage;
    public BulletMoveType bulletMoveType;
    public float moveSpeed;
    public float maxFlyDistance;
    public Vector3 halfExtents;
    public GameObject mod;
}
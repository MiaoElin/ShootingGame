using UnityEngine;

[CreateAssetMenu(menuName = "TM/BulletTM", fileName = "BulletTM_")]
public class BulletTM : ScriptableObject {
    public int typeID;
    public Mesh mesh;
    public int damage;
}
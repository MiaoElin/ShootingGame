using UnityEngine;

[CreateAssetMenu(menuName = "TM/GunTM", fileName = "GunTM_")]
public class GunTM : ScriptableObject {

    public int typeID;
    public GameObject gunObj;
    public int damage;
    public int bulletCountMax;
}
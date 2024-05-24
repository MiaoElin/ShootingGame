using UnityEngine;

[CreateAssetMenu(menuName = "TM/GunTM", fileName = "GunTM_")]
public class GunTM : ScriptableObject {

    public int typeID;
    public float shootRang;
    public GameObject gunObj;
    public int bulletCountMax;
}
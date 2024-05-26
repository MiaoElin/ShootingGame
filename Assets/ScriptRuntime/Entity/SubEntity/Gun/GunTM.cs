using UnityEngine;

[CreateAssetMenu(menuName = "TM/GunTM", fileName = "GunTM_")]
public class GunTM : ScriptableObject {

    public int typeID;
    public float shootRang;
    public GameObject mod;
    public int bulletTypeID;
    public int bulletCountMax;
    public Sprite gunIcon;
}
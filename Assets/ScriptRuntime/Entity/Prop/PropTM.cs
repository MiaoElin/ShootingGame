using UnityEngine;

[CreateAssetMenu(menuName = "TM/TMProp", fileName = "TM_Prop_")]
public class PropTM : ScriptableObject {
    public int typeID;
    public bool canBeDestory;
    public GameObject mod;
}
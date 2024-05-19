using UnityEngine;
using System.Collections.Generic;

public class LootEntity : MonoBehaviour {
    public int id;
    public int typeID;
    public bool isBox;
    public List<int> stuffTypeIDs;
    public List<int> stuffCount;
    [SerializeField] public MeshRenderer meshR;
    [SerializeField] public MeshFilter meshF;

}
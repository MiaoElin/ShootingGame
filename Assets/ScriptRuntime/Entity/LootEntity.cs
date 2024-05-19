using UnityEngine;
using System.Collections.Generic;
using System;

public class LootEntity : MonoBehaviour {
    public int id;
    public int typeID;
    public bool isBox;
    public List<int> stuffTypeIDs;
    public List<int> stuffCount;
    [SerializeField] public MeshRenderer meshR;
    [SerializeField] public MeshFilter meshF;


    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    internal void SetEulerAngles(Vector3 eulerAngles) {
        transform.eulerAngles = eulerAngles;
    }
}
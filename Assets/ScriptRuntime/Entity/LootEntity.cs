using UnityEngine;
using System.Collections.Generic;
using System;

public class LootEntity : MonoBehaviour {
    public int id;
    public int typeID;
    public string lootName;
    public bool isBox;
    public List<int> stuffTypeIDs;
    public List<int> stuffCount;
    public Transform modTransform;
    public Sprite signalSpr;


    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    public Vector3 Pos() {
        return transform.position;
    }

    internal void SetEulerAngles(Vector3 eulerAngles) {
        transform.eulerAngles = eulerAngles;
    }
}
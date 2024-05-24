using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TM/TMLoot", fileName = "TM_Loot")]
public class LootTM : ScriptableObject {

    public int typeID;
    public string lootName;
    public bool isBox;
    public List<int> stuffTypeIDs;
    public List<int> stuffCount;
    public GameObject mod;
    public Sprite signalSpr;
}
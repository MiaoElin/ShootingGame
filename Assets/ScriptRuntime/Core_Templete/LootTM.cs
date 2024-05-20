using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TM/LootTM", fileName = "LootTM")]
public class LootTM : ScriptableObject {

    public int typeID;
    public string lootName;
    public bool isBox;
    public List<int> stuffTypeIDs;
    public List<int> stuffCount;
    public GameObject meshR;
    public Mesh mesh;
    public Material material;

    public Sprite signalSpr;
}
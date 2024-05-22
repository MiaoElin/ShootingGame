using UnityEngine;

[CreateAssetMenu(menuName = "TM/TM_Map", fileName = "TM_Map_")]
public class MapTM : ScriptableObject {

    public int stageID;
    public RoleSpawnerTM[] roleSpawnerTMs;
}
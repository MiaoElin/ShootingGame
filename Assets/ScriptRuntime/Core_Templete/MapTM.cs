using UnityEngine;

[CreateAssetMenu(menuName = "TM/TM_Map", fileName = "TM_Map_")]
public class MapTM : ScriptableObject {

    public int stageID;
    public TerrainTM[] terrainTMs;
    // Terrain旋转和倍数和位置是固定的，可以按格子排列，所以可以只要TerrainTM，不需要再一个TerrainEM，TerrainEntity
    public RoleSpawnerTM[] roleSpawnerTMs;
    public LootSpawnerTM[] lootSpawnerTMs;
    public PropSpawnerTM[] propSpawnerTMs;
}
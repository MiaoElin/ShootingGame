using UnityEngine;

public static class TerrainDomain {

    public static TerrainEntity Spawn(GameContext ctx, Vector3 pos) {
        var terraiin = GameFactory.Terrain_Spawn(ctx, pos);
        ctx.terrainRepo.Add(terraiin);
        return terraiin;
    }
}
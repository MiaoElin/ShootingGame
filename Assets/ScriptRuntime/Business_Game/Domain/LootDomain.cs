using UnityEngine;

public static class LootDomain {

    public static LootEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Vector3 eulerAngles) {
        var loot = GameFactory.Loot_Spawn(ctx, typeID, pos, eulerAngles);
        ctx.lootRepo.Add(loot);
        return loot;
    }

    public static void Unspawn(GameContext ctx, LootEntity loot) {
        ctx.lootRepo.Remove(loot);
        ctx.poolService.ReturnLoot(loot);
    }

}
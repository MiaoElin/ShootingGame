using UnityEngine;

public static class SFXDomain {

    public static void Role_Walk_Play(GameContext ctx) {
        ctx.soundCore.Role_walk_Play(ctx.asset.configTM.sfx_role_Walk);
    }

    public static void Role_Walk_Stop(GameContext ctx) {
        ctx.soundCore.Role_walk_Stop();
    }

    public static void Role_EnterGroud(GameContext ctx) {
        ctx.soundCore.Role_EnterGround_Play(ctx.asset.configTM.sfx_role_EnterGround);
    }

    public static void Gun_Shoot(GameContext ctx) {
        ctx.soundCore.Gun_Shoot(ctx.asset.configTM.sfx_gun_shoot);
    }

    public static void Role_Pick(GameContext ctx) {
        ctx.soundCore.Role_Pick(ctx.asset.configTM.sfx_role_Pick);
    }

    public static void Bag_OpenClose(GameContext ctx) {
        ctx.soundCore.OpenClose_Bag(ctx.asset.configTM.sfx_Bag_OpenClse);
    }
}
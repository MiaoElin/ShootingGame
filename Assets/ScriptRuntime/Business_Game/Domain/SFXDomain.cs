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
}
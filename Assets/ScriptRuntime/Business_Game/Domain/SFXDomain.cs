using UnityEngine;

public static class SFXDomain {

    public static void Role_Walk_Play(GameContext ctx) {
        ctx.soundCore.Role_walk_Play(ctx.asset.configTM.role_Walk);
    }

    public static void Role_Walk_Stop(GameContext ctx) {
        ctx.soundCore.Role_walk_Stop();
    }
}
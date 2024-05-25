using System;
using UnityEngine;

public static class SFXDomain {

    public static void Role_Run_Play(GameContext ctx) {
        ctx.soundCore.Role_Run_Play(ctx.asset.configTM.sfx_role_Walk);
    }

    public static void Role_Run_Stop(GameContext ctx) {
        ctx.soundCore.Role_Run_Stop();
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

    internal static void Role_Walk_Play(GameContext ctx) {
        ctx.soundCore.Role_Walk_Play(ctx.asset.configTM.sfx_role_Walk);
    }

    internal static void Role_Walk_Stop(GameContext ctx) {
        ctx.soundCore.Role_Walk_Stop();
    }
}
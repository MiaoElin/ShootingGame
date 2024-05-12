using System;
using UnityEngine;

public static class GameBusiness_Normal {

    public static void Enter(GameContext ctx) {
        var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, 0, 0));
        ctx.ownerID = owner.id;
        ctx.fsm.EnterNormal();
    }

    public static void Tick(GameContext ctx, float dt) {

        PreTick(ctx, dt);

        var restTime = ctx.restTime;
        const float Interval = 0.01f;
        restTime += dt;
        if (restTime < Interval) {
            FixedTick(ctx, restTime);
            restTime = 0;
        } else {
            while (restTime >= Interval) {
                restTime -= Interval;
                FixedTick(ctx, Interval);
            }
        }

    }

    private static void PreTick(GameContext ctx, float dt) {
    }

    public static void FixedTick(GameContext ctx, float dt) {
        var owner = ctx.GetOwner();

        int roleLen = ctx.roleRepo.TakeAll(out var allRoles);
        for (int i = 0; i < roleLen; i++) {
            var role = allRoles[i];
            RoleDomain.Move(ctx, role);
        }
    }

    public static void LateTick(GameContext ctx, float dt) {

    }
}
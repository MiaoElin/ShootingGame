using System;
using UnityEngine;
using Cinemachine;

public static class GameBusiness_Normal {

    public static void Enter(GameContext ctx) {
        var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, 0, 0));
        ctx.ownerID = owner.id;

        // 设置相机跟随
        CameraDomain.EnterNormal(ctx);
        UIDomain.Panel_CrossHair_Open(ctx);
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

        LateTick(ctx, dt);
    }

    private static void PreTick(GameContext ctx, float dt) {
    }

    public static void FixedTick(GameContext ctx, float dt) {

        var owner = ctx.GetOwner();
        RoleFSMController.ApplyFsm(ctx, owner, dt);

        int roleLen = ctx.roleRepo.TakeAll(out var allRoles);
        for (int i = 0; i < roleLen; i++) {
            var role = allRoles[i];
            RoleDomain.Move(ctx, role, dt);
        }
        Physics.Simulate(dt);
    }

    public static void LateTick(GameContext ctx, float dt) {
        var owner = ctx.GetOwner();
        if (owner.isShootReady) {
            if (ctx.input.isShootReady) {
                ctx.input.isShootReady = false;
                owner.isShootReady = false;
                owner.roleFSMComponent.EnterNormal();
            }
        }
        if (!owner.isShootReady) {
            if (ctx.input.isShootReady) {
                ctx.input.isShootReady = false;
                owner.isShootReady = true;
                owner.roleFSMComponent.EnterShoot();
            }
        }
    }
}
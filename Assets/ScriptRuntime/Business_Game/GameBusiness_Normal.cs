using System;
using UnityEngine;
using Cinemachine;

public static class GameBusiness_Normal {

    public static void Enter(GameContext ctx) {
        var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, 0, 0));
        ctx.ownerID = owner.id;

        // 设置相机跟随
        ctx.cameraEntity.EnterNormal();
        ctx.cameraEntity.SetFollow(owner.transform);
        ctx.cameraEntity.SetLookAt(owner.shootLookAt);

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
        owner.SetLastPos(owner.GetPos());
        int roleLen = ctx.roleRepo.TakeAll(out var allRoles);
        for (int i = 0; i < roleLen; i++) {
            var role = allRoles[i];
            RoleDomain.Move(ctx, role, dt);
            role.SetForward_Normal(ctx.input.moveAxis, ctx.mainCamera.transform.forward, dt);
        }
        Physics.Simulate(dt);
    }

    public static void LateTick(GameContext ctx, float dt) {
    }
}
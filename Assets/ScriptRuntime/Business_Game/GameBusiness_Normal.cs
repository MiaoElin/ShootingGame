using System;
using UnityEngine;
using Cinemachine;

public static class GameBusiness_Normal {

    public static void Enter(GameContext ctx) {
        // // 获取场景里所有的LootEntity
        // var loots = Resources.FindObjectsOfTypeAll<LootEntity>();
        // foreach (var loot in loots) {
        //     if (loot.gameObject.activeSelf) {
        //         Debug.Log(loot.id);
        //         ctx.lootRepo.Add(loot);
        //     }
        // }

        // 生成临时loot
        LootDomain.Spawn(ctx, 102, new Vector3(0.5f, -3, 5), new Vector3(0, -150, 90));

        // 生成owner
        var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, -3, 0));
        ctx.ownerID = owner.id;
        owner.roleFSMComponent.EnterNormal();

        // 设置相机跟随
        CameraDomain.EnterNormal(ctx);

        // 打开准心UI
        UIDomain.Panel_CrossHair_Open(ctx);

        // 游戏进入Normal status 
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
        var owner = ctx.GetOwner();
        owner.isJumpKeyDown = ctx.input.isJumpKeyDown;
    }

    public static void FixedTick(GameContext ctx, float dt) {
        var owner = ctx.GetOwner();
        RoleFSMController.ApplyFsm(ctx, owner, dt);

        // int roleLen = ctx.roleRepo.TakeAll(out var allRoles);
        // for (int i = 0; i < roleLen; i++) {
        //     var role = allRoles[i];
        //     RoleDomain.Move(ctx, role, dt);
        //     RoleDomain.Jump(role);
        //     RoleDomain.Falling(role, dt);
        // }
        Physics.Simulate(dt);
        RoleDomain.GroundCheck(ctx, owner);
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
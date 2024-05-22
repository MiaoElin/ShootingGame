using System;
using UnityEngine;
using Cinemachine;

public static class GameBusiness_Normal {

    public static void Enter(GameContext ctx) {

        // 生成owner
        var owner = RoleDomain.Spawn(ctx, 100, VectorConst.OWNER_POS, VectorConst.OWNER_ROT, VectorConst.OWNER_SCALE, Ally.Player);
        ctx.ownerID = owner.id;
        owner.roleFSMComponent.EnterNormal();

        bool has = ctx.asset.TryGetMapTM(0, out var mapTM);
        if (!has) {
            Debug.LogError($"mapTypeID is not find");
            return;
        }

        var roleSpawnerTMs = mapTM.roleSpawnerTMs;
        if (roleSpawnerTMs != null) {
            for (int i = 0; i < roleSpawnerTMs.Length; i++) {
                var tm = roleSpawnerTMs[i];
                RoleDomain.Spawn(ctx, tm.roleTypeID, tm.pos, tm.rot, tm.scale, Ally.Monster);
            }
        }

        var lootSpawnerTMs = mapTM.lootSpawnerTMs;
        if (lootSpawnerTMs != null) {
            for (int i = 0; i < lootSpawnerTMs.Length; i++) {
                var tm = lootSpawnerTMs[i];
                LootDomain.Spawn(ctx, tm.lootTypeID, tm.pos, tm.rot, tm.scale);
            }
        }

        var propSpawnerTMs = mapTM.propSpawnerTMs;
        if (propSpawnerTMs != null) {
            for (int i = 0; i < propSpawnerTMs.Length; i++) {
                var tm = propSpawnerTMs[i];
                PropDomain.Spawn(ctx, tm.propTypeID, tm.pos, tm.rot, tm.scale);
            }
        }

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
        owner.isPickKeyDown = ctx.input.isPickKeyDown;
        // owner.isBagkeyDown = ctx.input.isBagkeyDown;
    }

    public static void FixedTick(GameContext ctx, float dt) {
        var owner = ctx.GetOwner();

        int roleLen = ctx.roleRepo.TakeAll(out var allRoles);
        for (int i = 0; i < roleLen; i++) {
            var role = allRoles[i];
            RoleDomain.Move(ctx, role, dt);
            RoleDomain.Jump(role);
            RoleDomain.Falling(role, dt);
        }
        RoleFSMController.ApplyFsm(ctx, owner, dt);

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

        if (!owner.isBagOpen) {
            if (ctx.input.isBagkeyDown) {
                // owner.isBagkeyDown = false; // 注意重置，不重置的话进入其他状态并没有根据input重置
                owner.isBagOpen = true;
                ctx.fsm.EnterOpenBag();
            }
        }

        // CameraDomain.MouseAxisTick(ctx);
    }
}
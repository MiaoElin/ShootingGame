using System;
using UnityEngine;
using Cinemachine;

public static class GameBusiness_Normal {

    public static void EnterStage(GameContext ctx) {

        // 生成owner
        var owner = RoleDomain.Spawn(ctx, 100, VectorConst.OWNER_POS, VectorConst.OWNER_ROT, VectorConst.OWNER_SCALE, Ally.Player);
        ctx.ownerID = owner.id;
        owner.roleFSMComponent.EnterNormal();
        bool has = ctx.asset.TryGetMapTM(0, out var mapTM);
        if (!has) {
            Debug.LogError($"mapTypeID is not find");
            return;
        }

        var terrainTMs = mapTM.terrainTMs;
        if (terrainTMs != null) {
            for (int i = 0; i < terrainTMs.Length; i++) {
                var tm = terrainTMs[i];
                TerrainDomain.Spawn(ctx, tm.gridPos);
            }
        }

        var roleSpawnerTMs = mapTM.roleSpawnerTMs;
        if (roleSpawnerTMs != null) {
            for (int i = 0; i < roleSpawnerTMs.Length; i++) {
                var tm = roleSpawnerTMs[i];
                var role = RoleDomain.Spawn(ctx, tm.roleTypeID, tm.pos, tm.rot, tm.scale, Ally.Monster);
                UIDomain.H_HpBar_Open(ctx, role.id, role.hpMax);
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

        ref var restTime = ref ctx.restTime;
        const float Interval = 0.01f;
        restTime += dt;
        if (restTime < Interval) {
            FixedTick(ctx, restTime);
            restTime = 0;
        } else {
            while (restTime >= Interval) {
                FixedTick(ctx, Interval);
                restTime -= Interval;
            }
        }

        LateTick(ctx, dt);
    }

    private static void PreTick(GameContext ctx, float dt) {
        var owner = ctx.GetOwner();
        owner.isJumpKeyDown = ctx.input.isJumpKeyDown;
        owner.isPickKeyDown = ctx.input.isPickKeyDown;
        owner.isSlowKeyDown = ctx.input.isRuningKeyDown;
    }

    public static void FixedTick(GameContext ctx, float dt) {
        var owner = ctx.GetOwner();

        int roleLen = ctx.roleRepo.TakeAll(out var allRoles);
        for (int i = 0; i < roleLen; i++) {
            var role = allRoles[i];
            RoleDomain.Move(ctx, role, dt);
            RoleDomain.Jump(role);
            RoleDomain.Falling(role, dt);
            RoleDomain.UpdateHpBar(ctx, role);
        }
        RoleFSMController.ApplyFsm(ctx, owner, dt);

        // 移动子弹
        var bulletLen = ctx.bulletRepo.TakeAll(out var allBullets);
        for (int i = 0; i < bulletLen; i++) {
            var bullet = allBullets[i];
            BulletDomain.Move(bullet, dt);
            BulletDomain.CheckCollision(bullet, dt);
        }

        // 子弹销毁
        for (int i = 0; i < bulletLen; i++) {
            var bullet = allBullets[i];
            if (bullet.isDead) {
                BulletDomain.Unspawn(ctx, bullet);
            }
        }

        // 销毁role
        for (int i = 0; i < roleLen; i++) {
            var role = allRoles[i];
            if (role.isDead) {
                // 播死亡动画
                role.Anim_Dead();
                if (role.deadTimer > 0) {
                    role.deadTimer -= dt;
                } else {
                    RoleDomain.Unspawn(ctx, role);
                    UIDomain.H_HpBar_Close(ctx, role.id);
                }

            }
        }

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

        if (Input.GetKeyDown(KeyCode.Q)) {
            owner.Anim_Climb();
        }

        // CameraDomain.MouseAxisTick(ctx);
    }
}
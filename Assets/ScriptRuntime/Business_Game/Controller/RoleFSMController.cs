using System;
using UnityEngine;

public static class RoleFSMController {

    public static void ApplyFsm(GameContext ctx, RoleEntity role, float dt) {
        var status = role.roleFSMComponent.status;
        if (status != RoleStatus.Dead) {
            ApplyAny(ctx, role, dt);
        }
        if (status == RoleStatus.Normal) {
            ApplyNormal(ctx, role, dt);
        } else if (status == RoleStatus.Shoot) {
            ApplyShoot(ctx, role);
        } else if (status == RoleStatus.FPS) {
            ApplyFPS(ctx, role, dt);
        }
    }

    private static void ApplyShoot(GameContext ctx, RoleEntity role) {
        var fsm = role.roleFSMComponent;
        if (fsm.isShoot) {
            fsm.isShoot = false;
            CameraDomain.EnterShoot(ctx);
            ctx.GetOwner().ShowBodyMod();
        }
        RoleDomain.SetForward_Shoot(ctx, role);
    }

    private static void ApplyNormal(GameContext ctx, RoleEntity role, float dt) {
        var fsm = role.roleFSMComponent;
        if (fsm.isNormal) {
            fsm.isNormal = false;
            CameraDomain.EnterNormal(ctx);
            ctx.GetOwner().ShowBodyMod();
            UIDomain.Panel_CrossHair_Open_TPS(ctx);
        }
        RoleDomain.SetForward_Normal(ctx, role, dt);
    }

    public static void ApplyFPS(GameContext ctx, RoleEntity role, float dt) {
        var fsm = role.roleFSMComponent;
        if (fsm.isFPS) {
            fsm.isFPS = false;
            CameraDomain.EnterFPS(ctx);
            ctx.GetOwner().HideBodyMod();
            UIDomain.Panel_CrossHair_Open_FPS(ctx);
        }

    }

    private static void ApplyAny(GameContext ctx, RoleEntity role, float dt) {
        RoleDomain.Move(ctx, role, dt);
        RoleDomain.Jump(role);
        RoleDomain.Falling(role, dt);
        RoleDomain.SearchLoot(ctx, role, out var nearlyLoot);
        RoleDomain.PickUpLoot(ctx, role, nearlyLoot);
        RoleDomain.ShootBullet(ctx, role);
        RoleDomain.Monster_Hit(ctx, role, dt);
    }
}
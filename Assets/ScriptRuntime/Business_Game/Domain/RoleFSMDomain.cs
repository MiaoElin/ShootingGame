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
        }
    }

    private static void ApplyShoot(GameContext ctx, RoleEntity role) {
        var fsm = role.roleFSMComponent;
        if (fsm.isShoot) {
            fsm.isShoot = false;
            CameraDomain.EnterShoot(ctx);
        }
        RoleDomain.SetForward_Shoot(ctx, role);
    }

    private static void ApplyNormal(GameContext ctx, RoleEntity role, float dt) {
        var fsm = role.roleFSMComponent;
        if (fsm.isNormal) {
            fsm.isNormal = false;
            CameraDomain.EnterNormal(ctx);
        }
        RoleDomain.SetForward_Normal(ctx, role, dt);
    }

    private static void ApplyAny(GameContext ctx, RoleEntity role, float dt) {
        RoleDomain.Move(ctx, role, dt);
        RoleDomain.Jump(role);
        RoleDomain.Falling(role, dt);
        RoleDomain.SearchLoot(ctx, role);
    }
}
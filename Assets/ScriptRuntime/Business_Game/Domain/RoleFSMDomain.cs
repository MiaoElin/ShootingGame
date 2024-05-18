using System;
using UnityEngine;

public static class RoleFSMDomain {

    public static void ApplyFsm(GameContext ctx, RoleEntity role) {
        var status = role.roleFSMComponent.status;
        if (status != RoleStatus.Dead) {
            ApplyAny(ctx);
        }

        if (status == RoleStatus.Normal) {
            ApplyNormal(ctx);
        } else if (status == RoleStatus.Shoot) {
            ApplyShoot(ctx);
        }
    }

    private static void ApplyShoot(GameContext ctx) {
        throw new NotImplementedException();
    }

    private static void ApplyNormal(GameContext ctx) {
        throw new NotImplementedException();
    }

    private static void ApplyAny(GameContext ctx) {
        throw new NotImplementedException();
    }
}
using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        var role = GameFactory.Role_Spawn(ctx, typeID, pos);
        ctx.roleRepo.Add(role);
        return role;
    }

    public static void Move(GameContext ctx, RoleEntity role, float dt) {
        if (role.moveType == MoveType.ByInput) {
            Vector3 dir = ctx.input.moveAxis;
            role.Move(dir, dt);
            // animator
            role.Anim_Run();
            // sfx
            if (dir != Vector3.zero) {
                SFXDomain.Role_Walk_Play(ctx);
            } else {
                SFXDomain.Role_Walk_Stop(ctx);
            }
        }
    }

    public static void SetForward_Normal(GameContext ctx, RoleEntity role, float dt) {
        role.SetForward_Normal(ctx.input.moveAxis, ctx.cameraEntity.GetPos(), dt);
    }

    public static void SetForward_Shoot(GameContext ctx, RoleEntity role) {
        role.SetForward_Shoot(ctx.cameraEntity.GetPos());
    }
}
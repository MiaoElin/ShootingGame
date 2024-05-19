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

    public static void Jump(RoleEntity role) {
        bool isJump = role.IsJump();
        if (isJump) {
            // anim
            role.Anim_Jump();
            // sfx

            // vfx
        }
    }

    public static void Falling(RoleEntity role, float dt) {
        role.Falling(dt);
    }

    // rayCast
    public static void GroundCheck(GameContext ctx, RoleEntity role) {
        if (role.Velocity().y > 0) {
            return;
        }
        var layerMask = 1 << LayerMaskConst.GROUND;
        var quat = Quaternion.LookRotation(role.GetForward(), Vector3.up);
        var hit = Physics.OverlapBox(role.GetPos(), new Vector3(0.6f, 0.1f, 0.3f), quat, layerMask);

        if (hit.Length != 0) {
            if (!role.isInGround) {
                // role.isEnterGround = true;
                SFXDomain.Role_EnterGroud(ctx);
            }
            role.isInGround = true;
        } else {
            role.isInGround = false;
        }

    }
}
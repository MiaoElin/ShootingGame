using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        var role = GameFactory.Role_Spawn(ctx, typeID, pos);
        ctx.roleRepo.Add(role);
        return role;
    }

    public static void Move(GameContext ctx, RoleEntity role) {
        if (role.moveType == MoveType.ByInput) {
            role.Move(ctx.input.moveAxis);
            role.Anim_Run();
        }
    }
}
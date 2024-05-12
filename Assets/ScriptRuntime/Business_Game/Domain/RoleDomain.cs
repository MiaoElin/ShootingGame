using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        var role = GameFactory.CreateRole(ctx, typeID, pos);
        ctx.roleRepo.Add(role);
        return role;
    }
}
using UnityEngine;

public static class GameFactory {

    public static RoleEntity CreateRole(GameContext ctx, int typeId, Vector2 pos) {
        bool has = ctx.asset.TryGetRoleTM(typeId, out var tm);
        if (!has) {
            Debug.LogError($"GameFactory.CreateRole {typeId} is not find");
        }
        ctx.asset.TryGetEntity_Prefab(typeof(RoleEntity).Name, out var prefab);
        RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
        role.body = GameObject.Instantiate(tm.body, role.transform);
        role.Ctor(role.body.GetComponent<Animator>());
        role.typeId = typeId;
        role.id = ctx.iDService.roleIdRecord++;
        role.hp = tm.hpMax;
        role.hpMax = tm.hpMax;
        role.moveSpeed = tm.moveSpeed;
        return role;
    }
}
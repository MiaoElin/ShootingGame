using UnityEngine;

public static class GameFactory {

    public static RoleEntity Role_Spawn(GameContext ctx, int typeId, Vector2 pos) {
        bool has = ctx.asset.TryGetRoleTM(typeId, out var tm);
        if (!has) {
            Debug.LogError($"GameFactory.CreateRole {typeId} is not find");
        }
        var role = ctx.poolService.GetRole();
        role.body = GameObject.Instantiate(tm.body, role.transform);
        role.Ctor(role.body.GetComponent<Animator>());
        role.SetPos(pos);
        role.typeId = typeId;
        role.id = ctx.iDService.roleIdRecord++;
        role.hp = tm.hpMax;
        role.hpMax = tm.hpMax;
        role.moveSpeed = tm.moveSpeed;
        role.moveType = tm.moveType;
        role.gameObject.SetActive(true);
        return role;
    }

    public static RoleEntity Role_Create(GameContext ctx) {
        ctx.asset.TryGetEntity_Prefab(typeof(RoleEntity).Name, out var prefab);
        RoleEntity role = GameObject.Instantiate(prefab, ctx.poolService.rolePoolGroup).GetComponent<RoleEntity>();
        role.gameObject.SetActive(false);
        return role;
    }
}
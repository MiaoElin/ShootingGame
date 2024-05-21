using UnityEngine;

public static class GameFactory {

    public static RoleEntity Role_Spawn(GameContext ctx, int typeId, Vector2 pos) {
        bool has = ctx.asset.TryGetRoleTM(typeId, out var tm);
        if (!has) {
            Debug.LogError($"GameFactory.CreateRole {typeId} is not find");
        }
        var role = ctx.poolService.GetRole();
        role.body = GameObject.Instantiate(tm.body, role.transform);
        role.Ctor(role.body.GetComponent<Animator>(), role.body.GetComponent<GunSubEntity>());
        role.SetPos(pos);
        role.typeId = typeId;
        role.id = ctx.iDService.roleIdRecord++;
        role.hp = tm.hpMax;
        role.hpMax = tm.hpMax;
        role.moveSpeed = tm.moveSpeed;
        role.moveType = tm.moveType;
        role.gravity = tm.gravity;
        role.jumpingForce = tm.jumpingForce;
        role.gameObject.SetActive(true);
        return role;
    }

    public static RoleEntity Role_Create(GameContext ctx) {
        ctx.asset.TryGetEntity_Prefab(typeof(RoleEntity).Name, out var prefab);
        RoleEntity role = GameObject.Instantiate(prefab, ctx.poolService.rolePoolGroup).GetComponent<RoleEntity>();
        role.gameObject.SetActive(false);
        return role;
    }

    public static LootEntity Loot_Spawn(GameContext ctx, int typeID, Vector3 pos, Vector3 eulerAngles) {
        bool has = ctx.asset.TryGetLootTM(typeID, out var tm);
        if (!has) {
            Debug.LogError($"GameFactory.LootSpawn {typeID} is not find");
        }
        var loot = ctx.poolService.GetPool();
        loot.typeID = typeID;
        loot.lootName = tm.lootName;
        loot.SetPos(pos);
        loot.SetEulerAngles(eulerAngles);
        loot.id = ctx.iDService.lootIdRecord++;
        loot.isBox = tm.isBox;
        loot.stuffTypeIDs = tm.stuffTypeIDs;
        loot.stuffCount = tm.stuffCount;
        loot.meshF.mesh = tm.mesh;
        loot.meshR.material = tm.material;
        loot.signalSpr = tm.signalSpr;
        loot.gameObject.SetActive(true);
        return loot;
    }

    public static LootEntity Loot_Create(GameContext ctx) {
        ctx.asset.TryGetEntity_Prefab(typeof(LootEntity).Name, out var prefab);
        var loot = GameObject.Instantiate(prefab, ctx.poolService.rolePoolGroup).GetComponent<LootEntity>();
        loot.gameObject.SetActive(false);
        return loot;
    }

    public static StuffModel Stuff_Create(GameContext ctx, int typeID, int count) {
        StuffModel stuff = new StuffModel();
        stuff.typeID = typeID;
        stuff.count = count;
        ctx.asset.TryGetStuffTM(typeID, out var tm);
        stuff.stuffType = tm.stuffType;
        stuff.countMax = tm.countMax;
        stuff.gunTypeID = tm.gunTypeID;
        stuff.isReHP = tm.isReHP;
        stuff.reHPMax = tm.reHPMax;
        stuff.isReStrength = tm.isReStrength;
        stuff.reStrengthMax = tm.reStrengthMax;
        return stuff;
    }
}
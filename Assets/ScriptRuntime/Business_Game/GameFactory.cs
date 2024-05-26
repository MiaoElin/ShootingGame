using System;
using UnityEngine;

public static class GameFactory {

    public static RoleEntity Role_Spawn(GameContext ctx, int typeId, Vector3 pos, Vector3 rot, Vector3 scale, Ally ally) {
        bool has = ctx.asset.TryGetRoleTM(typeId, out var tm);
        if (!has) {
            Debug.LogError($"GameFactory.CreateRole {typeId} is not find");
        }
        var role = ctx.poolService.GetRole();
        role.body = GameObject.Instantiate(tm.body, role.transform);
        role.mod = role.body.transform.Find("Mesh").gameObject;
        role.Ctor(role.body.GetComponent<Animator>(), role.body.GetComponentInChildren<GunSubEntity>());
        role.SetPos(pos);
        role.SetBodyRotation(rot);
        role.SetScale(scale);
        role.typeId = typeId;
        role.ally = ally;
        role.height = tm.height;
        role.walkSpeed = tm.walkSpeed;
        role.runSpeed = tm.runSpeed;
        if (ally == Ally.Monster) {
            role.moveSpeed = tm.walkSpeed;
        }
        role.speedUpDuration = tm.speedUpDuration;
        role.speedDownDuration = tm.speedDownDuration;
        role.id = ctx.iDService.roleIdRecord++;
        role.hp = tm.hpMax;
        role.hpMax = tm.hpMax;
        role.deadTimer = tm.deadTimer;
        role.moveType = tm.moveType;
        role.viewRange = tm.viewRange;
        role.attackDamage = tm.attackDamage;
        role.attackTime = 0;
        role.before_attackDuration = tm.before_attackDuration;
        role.after_attackDuration = tm.after_attackDuration;
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

    public static LootEntity Loot_Spawn(GameContext ctx, int typeID, Vector3 pos, Vector3 eulerAngles, Vector3 scale) {
        bool has = ctx.asset.TryGetLootTM(typeID, out var tm);
        if (!has) {
            Debug.LogError($"GameFactory.LootSpawn {typeID} is not find");
        }
        var loot = ctx.poolService.GetPool();
        loot.typeID = typeID;
        loot.lootName = tm.lootName;
        loot.SetPos(pos);
        loot.SetEulerAngles(eulerAngles);
        loot.SetScale(scale);
        loot.id = ctx.iDService.lootIdRecord++;
        loot.isBox = tm.isBox;
        loot.stuffTypeIDs = tm.stuffTypeIDs;
        loot.stuffCount = tm.stuffCount;
        GameObject.Instantiate<GameObject>(tm.mod, loot.modTransform);
        loot.signalSpr = tm.signalSpr;
        loot.gameObject.SetActive(true);
        return loot;
    }

    public static LootEntity Loot_Create(GameContext ctx) {
        ctx.asset.TryGetEntity_Prefab(typeof(LootEntity).Name, out var prefab);
        var loot = GameObject.Instantiate(prefab, ctx.poolService.lootPoolGroup).GetComponent<LootEntity>();
        loot.gameObject.SetActive(false);
        return loot;
    }

    public static PropEntity Prop_Spawn(GameContext ctx, int typeID, Vector3 pos, Vector3 rot, Vector3 scale) {
        bool has = ctx.asset.TryGetPropTM(typeID, out var tm);
        if (!has) {
            Debug.LogError($"GameFactory.Prop_Spawn is not find {typeID}");
        }
        var prop = ctx.poolService.GetProp();
        prop.typeId = typeID;
        GameObject.Instantiate(tm.mod, prop.modTransform);
        prop.SetPos(pos);
        prop.SetRotaion(rot);
        prop.SetScale(scale);
        prop.id = ctx.iDService.propIdRecord++;
        prop.gameObject.SetActive(true);
        return prop;
    }

    internal static PropEntity Prop_Create(GameContext ctx) {
        ctx.asset.TryGetEntity_Prefab(typeof(PropEntity).Name, out var prefab);
        var prop = GameObject.Instantiate(prefab, ctx.poolService.propPoolGroup).GetComponent<PropEntity>();
        prop.gameObject.SetActive(false);
        return prop;
    }

    public static StuffModel Stuff_Create(GameContext ctx, int typeID, int count) {
        StuffModel stuff = new StuffModel();
        stuff.typeID = typeID;
        stuff.count = count;
        ctx.asset.TryGetStuffTM(typeID, out var tm);
        stuff.stuffType = tm.stuffType;
        stuff.stuffName = tm.stuffName;
        stuff.countMax = tm.countMax;
        // gun
        stuff.hasGun = tm.hasGun;
        stuff.gunTypeID = tm.gunTypeID;
        // bulletBox
        stuff.hasBuletBox = tm.hasBuletBox;
        stuff.bulletBoxTypeID = tm.bulletBoxTypeID;
        // rehp
        stuff.isReHP = tm.isReHP;
        stuff.reHPMax = tm.reHPMax;
        // reStrength
        stuff.isReStrength = tm.isReStrength;
        stuff.reStrengthMax = tm.reStrengthMax;
        // 背包显示的sprite
        stuff.Spr = tm.stuffSpr;
        return stuff;
    }

    public static BulletEntity Bullet_Create(GameContext ctx) {
        ctx.asset.TryGetEntity_Prefab(typeof(BulletEntity).Name, out var prefab);
        var bullet = GameObject.Instantiate(prefab, ctx.poolService.bulletGroup).GetComponent<BulletEntity>();
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public static BulletEntity Bullet_Spawn(GameContext ctx, int typeID, Vector3 pos, Ally ally) {
        ctx.asset.TryGetBulletTM(typeID, out var tm);
        if (!tm) {
            Debug.LogError($"GameFactory.Bullet_Spawn {typeID} is not find");
        }
        var bullet = ctx.poolService.GetBullet();
        bullet.typeID = tm.typeID;
        bullet.ally = ally;
        bullet.isDead = false;
        bullet.Ctor(tm.mod, tm.moveSpeed, tm.maxFlyDistance);
        bullet.halfExtents = tm.halfExtents;
        bullet.SetPos(pos);
        bullet.id = ctx.iDService.bulletIdRecord++;
        bullet.damage = tm.damage;
        bullet.bulletMoveType = tm.bulletMoveType;
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public static TerrainEntity Terrain_Spawn(GameContext ctx, Vector3 gridPos) {
        ctx.asset.TryGetTerrainTM(gridPos, out var tm);
        if (!tm) {
            Debug.LogError($"GameFactory.Terrain_Spawn {gridPos} is not find");
        }
        ctx.asset.TryGetEntity_Prefab(typeof(TerrainEntity).Name, out var prefab);
        TerrainEntity terrain = GameObject.Instantiate(prefab, ctx.poolService.terrainGroup).GetComponent<TerrainEntity>();
        terrain.Ctor(tm.mod);
        terrain.SetPos(gridPos);
        return terrain;
    }

    // public static GunSubEntity Gun_Create(GameContext ctx, int typeID, Transform gunTransform) {
    //     ctx.asset.TryGetGunTM(typeID, out var tm);
    //     if (!tm) {
    //         Debug.LogError($"GameFactory.Gun_Create {typeID} is not find");
    //     }
    //     ctx.asset.TryGetEntity_Prefab(typeof(GunSubEntity).Name, out var prefab);
    //     GunSubEntity gun = GameObject.Instantiate(prefab, gunTransform).GetComponent<GunSubEntity>();
    //     gun.typeID = typeID;
    //     gun.shootRang = tm.shootRang;
    //     gun.bulletTypeID = tm.bulletTypeID;
    //     gun.bulletCountMax = tm.bulletCountMax;
    //     gun.gunIcon = tm.gunIcon;
    //     GameObject.Instantiate(tm.mod, gun.transform);
    //     return gun;
    // }
}
using UnityEngine;
using System;

public class PoolService {

    public Transform terrainGroup;

    Pool<RoleEntity> rolePool;
    public Transform rolePoolGroup;

    Pool<LootEntity> lootPool;
    public Transform lootPoolGroup;

    Pool<PropEntity> propPool;
    public Transform propPoolGroup;

    Pool<BulletEntity> bulletPool;
    public Transform bulletGroup;

    public PoolService() {
    }

    public void Init(Func<RoleEntity> role_Create, Func<LootEntity> loot_Create, Func<PropEntity> prop_Create, Func<BulletEntity> bullet_Create) {
        terrainGroup = new GameObject("TerrianGroup").transform;

        rolePoolGroup = new GameObject("RolePool").transform;
        rolePool = new Pool<RoleEntity>(role_Create, 10);

        lootPoolGroup = new GameObject("LootPool").transform;
        lootPool = new Pool<LootEntity>(loot_Create, 20);

        propPoolGroup = new GameObject("PropGroup").transform;
        propPool = new Pool<PropEntity>(prop_Create, 20);

        bulletGroup = new GameObject("BulletGroup").transform;
        bulletPool = new Pool<BulletEntity>(bullet_Create, 100);

    }

    public RoleEntity GetRole() {
        return rolePool.Get();
    }

    public void ReTurnRole(RoleEntity role) {
        rolePool.Return(role);
    }

    public LootEntity GetPool() {
        return lootPool.Get();
    }

    public void ReturnLoot(LootEntity loot) {
        lootPool.Return(loot);
    }

    public PropEntity GetProp() {
        return propPool.Get();
    }

    public void Return(PropEntity prop) {
        propPool.Return(prop);
    }

    public BulletEntity GetBullet() {
        return bulletPool.Get();
    }

    public void ReturnBullet(BulletEntity bullet) {
        bulletPool.Return(bullet);
    }
}
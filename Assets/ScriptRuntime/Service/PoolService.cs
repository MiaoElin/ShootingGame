using UnityEngine;
using System;

public class PoolService {

    Pool<RoleEntity> rolePool;
    public Transform rolePoolGroup;

    Pool<LootEntity> lootPool;
    public Transform lootPoolGroup;

    Pool<PropEntity> propPool;
    public Transform propPoolGroup;

    public PoolService() {
    }

    public void Init(Func<RoleEntity> role_Create, Func<LootEntity> loot_Create, Func<PropEntity> prop_Create) {
        rolePoolGroup = new GameObject("RolePool").transform;
        rolePool = new Pool<RoleEntity>(role_Create, 10);

        lootPoolGroup = new GameObject("LootPool").transform;
        lootPool = new Pool<LootEntity>(loot_Create, 20);

        propPoolGroup = new GameObject("PropGroup").transform;
        propPool = new Pool<PropEntity>(prop_Create, 20);
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
}
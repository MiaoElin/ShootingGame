using UnityEngine;
using System;

public class PoolService {

    Pool<RoleEntity> rolePool;
    Pool<LootEntity> lootPool;
    public Transform rolePoolGroup;

    public PoolService() {
    }

    public void Init(Func<RoleEntity> role_Create, Func<LootEntity> loot_Create) {
        rolePoolGroup = new GameObject("RolePool").transform;
        rolePool = new Pool<RoleEntity>(role_Create, 1);
        lootPool = new Pool<LootEntity>(loot_Create, 0);
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

    public void ReturnPool(LootEntity loot) {
        lootPool.Return(loot);
    }
}
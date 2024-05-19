using UnityEngine;
using System;

public class PoolService {

    Pool<RoleEntity> rolePool;
    public Transform rolePoolGroup;

    public PoolService() {
    }

    public void Init(Func<RoleEntity> role_Create) {
        rolePoolGroup = new GameObject("RolePool").transform;
        rolePool = new Pool<RoleEntity>(role_Create, 1);
    }

    public RoleEntity GetRole() {
        return rolePool.Get();
    }
}
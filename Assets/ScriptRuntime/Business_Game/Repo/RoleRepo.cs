using UnityEngine;
using System.Collections.Generic;

public class RoleRepo {

    Dictionary<int, RoleEntity> all;
    RoleEntity[] temp;

    public RoleRepo() {
        all = new Dictionary<int, RoleEntity>();
        temp = new RoleEntity[1000];
    }

    public void Add(RoleEntity role) {
        all.Add(role.id, role);
    }

    public bool Tryget(int id, out RoleEntity role) {
        return all.TryGetValue(id, out role);
    }
}
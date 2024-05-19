using UnityEngine;
using System.Collections.Generic;

public class RoleRepo {

    Dictionary<int, RoleEntity> all;
    RoleEntity[] temp;

    public RoleRepo() {
        all = new Dictionary<int, RoleEntity>();
        temp = new RoleEntity[1024];
    }

    public void Add(RoleEntity role) {
        all.Add(role.id, role);
    }

    public bool Tryget(int id, out RoleEntity role) {
        return all.TryGetValue(id, out role);
    }

    public int TakeAll(out RoleEntity[] allRoles) {
        if (temp.Length < all.Count) {
            temp = new RoleEntity[(int)(all.Count * 1.5f)];
        }
        all.Values.CopyTo(temp, 0);
        allRoles = temp;
        return all.Count;
    }
}
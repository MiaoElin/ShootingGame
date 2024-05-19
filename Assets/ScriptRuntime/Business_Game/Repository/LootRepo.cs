using UnityEngine;
using System.Collections.Generic;

public class LootRepo {

    Dictionary<int, LootEntity> all;
    LootEntity[] temp;

    public LootRepo() {
        all = new Dictionary<int, LootEntity>();
        temp = new LootEntity[1024];
    }

    public void Add(LootEntity loot) {
        all.Add(loot.id, loot);
    }

    public void Remove(LootEntity loot) {
        all.Remove(loot.id);
    }

    public bool Tryget(int id, out LootEntity loot) {
        return all.TryGetValue(id, out loot);
    }

    public int TakeAll(out LootEntity[] allLoots) {
        if (temp.Length < all.Count) {
            temp = new LootEntity[(int)(all.Count * 1.5f)];
        }
        all.Values.CopyTo(temp, 0);
        allLoots = temp;
        return all.Count;
    }
}
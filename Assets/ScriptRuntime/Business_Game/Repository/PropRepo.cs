using UnityEngine;
using System.Collections.Generic;

public class PropRepo {

    Dictionary<int, PropEntity> all;
    PropEntity[] temp;

    public PropRepo() {
        all = new Dictionary<int, PropEntity>();
        temp = new PropEntity[256];
    }

    public void Add(PropEntity prop) {
        all.Add(prop.id, prop);
    }

    public void Remove(PropEntity prop) {
        all.Remove(prop.id);
    }

    public bool Tryget(int id, out PropEntity prop) {
        return all.TryGetValue(id, out prop);
    }

    public int TakeAll(out PropEntity[] allProps) {
        if (temp.Length < all.Count) {
            temp = new PropEntity[(int)(all.Count * 1.5f)];
        }
        all.Values.CopyTo(temp, 0);
        allProps = temp;
        return all.Count;
    }
}
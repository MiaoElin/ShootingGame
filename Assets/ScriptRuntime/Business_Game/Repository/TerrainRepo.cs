using UnityEngine;
using System.Collections.Generic;

public class TerrainRepo {
    Dictionary<Vector3, TerrainEntity> all;
    TerrainEntity[] temp;

    public TerrainRepo() {
        all = new Dictionary<Vector3, TerrainEntity>();
        temp = new TerrainEntity[256];
    }

    public void Add(TerrainEntity terraiin) {
        all.Add(terraiin.gridPos, terraiin);
    }

    public void Remove(TerrainEntity terraiin) {
        all.Remove(terraiin.gridPos);
    }

    public bool Tryget(Vector3 gridPos, out TerrainEntity terraiin) {
        return all.TryGetValue(gridPos, out terraiin);
    }

    public int TakeAll(out TerrainEntity[] allLoots) {
        if (temp.Length < all.Count) {
            temp = new TerrainEntity[(int)(all.Count * 1.5f)];
        }
        all.Values.CopyTo(temp, 0);
        allLoots = temp;
        return all.Count;
    }
}
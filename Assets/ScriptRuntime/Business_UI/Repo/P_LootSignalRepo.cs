using UnityEngine;
using System.Collections.Generic;

public class P_LootSignalRepo {
    Dictionary<int, Panel_LootSignal> all;

    public P_LootSignalRepo() {
        all = new Dictionary<int, Panel_LootSignal>();
    }

    public void Add(int id, Panel_LootSignal panel) {
        all.Add(id, panel);
    }

    public bool Tryget(int id, out Panel_LootSignal panel) {
        return all.TryGetValue(id, out panel);
    }
}
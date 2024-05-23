using UnityEngine;
using System.Collections.Generic;

public class HpBarRepo {

    Dictionary<int, HUD_HpBar> all;

    public HpBarRepo() {
        all = new Dictionary<int, HUD_HpBar>();
    }

    public void Add(int id, HUD_HpBar hpbar) {
        all.Add(id, hpbar);
    }

    public bool TryGet(int id, out HUD_HpBar hpBar) {
        return all.TryGetValue(id, out hpBar);
    }

}
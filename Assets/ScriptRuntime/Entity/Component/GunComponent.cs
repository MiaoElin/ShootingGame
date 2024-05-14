using System;
using UnityEngine;
using System.Collections.Generic;

public class GunComponent {

    List<GunSubEntity> allGuns;
    GunSubEntity[] temp;

    public GunComponent() {
        allGuns = new List<GunSubEntity>();
        temp = new GunSubEntity[5];
    }

    public void Add(GunSubEntity gun) {
        allGuns.Add(gun);
    }

    public void Remove(GunSubEntity gun) {
        allGuns.Remove(gun);
    }

    public GunSubEntity Find(int skillTypeId) {
        return allGuns.Find(gun => gun.typeID == skillTypeId);
    }

    public void Foreach(Action<GunSubEntity> action) {
        allGuns.ForEach(action);
    }
}
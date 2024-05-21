using UnityEngine;

public class StuffComponent {
    StuffModel[] stuffs;
    int capacity;

    public StuffComponent() {
        stuffs = new StuffModel[capacity];
    }

    public void Ctor(int capacity) {
        this.capacity = capacity;
        stuffs = new StuffModel[capacity];
    }

    public int Add(StuffModel newStuff) {
        int surplus = 0;
        bool has = false;
        for (int i = 0; i < capacity; i++) {
            var stuff = stuffs[i];
            if (stuff == null) {
                continue;
            }
            if (stuff.typeID == newStuff.typeID) {
                has = true;
                int count = stuff.count + newStuff.count;
                if (count > stuff.countMax) {
                    surplus = newStuff.count - (stuff.countMax - stuff.count);
                    stuff.count = stuff.countMax;
                    has = false;
                }
            }
        }

        if (!has) {
            for (int i = 0; i < capacity; i++) {
                var stuff = stuffs[i];
                if (stuff != null) {
                    continue;
                }
                if (newStuff.stuffType == StuffType.Supply) {
                    if (i > CommonConst.GRID_MAXCOUNT_PERGROUP) {
                        break;
                    }
                    stuff = newStuff;
                } else if (newStuff.stuffType == StuffType.Weapon) {
                    if (i > CommonConst.GRID_MAXCOUNT_PERGROUP * 2) {
                        break;
                    }
                    stuff = newStuff;
                }
            }
        }

        return surplus;

    }
}
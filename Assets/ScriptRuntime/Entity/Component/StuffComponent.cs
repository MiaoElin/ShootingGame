using UnityEngine;
using System;

public class StuffComponent {
    StuffModel[] stuffs;
    int capacity;

    public StuffComponent() {
        capacity = CommonConst.BAG_MAXCOUNT;
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
                if (stuff != null && stuff.hasStuff) {
                    continue;
                }
                if (newStuff.stuffType == StuffType.Supply) {
                    if (i >= CommonConst.BAG_MAXCOUNT_PERGROUP) {
                        break;
                    }
                    newStuff.index = i;
                    newStuff.hasStuff = true;
                    stuffs[i] = newStuff;
                    break;
                } else if (newStuff.stuffType == StuffType.Weapon) {
                    if (i < CommonConst.BAG_MAXCOUNT_PERGROUP) {
                        continue;
                    }
                    if (i >= CommonConst.BAG_MAXCOUNT_PERGROUP * 2) {
                        break;
                    }
                    // stuff = newStuff;  stuff 是局部变量，要改变stuffs里的
                    newStuff.index = i;
                    newStuff.hasStuff = true;
                    stuffs[i] = newStuff;
                    break;
                }
            }
        }

        return surplus;
    }

    public void Foreach(Action<StuffModel> action) {
        for (int i = 0; i < capacity; i++) {
            var stuff = stuffs[i];
            if (stuff == null) {
                continue;
            }
            action(stuff);
        }
    }
}
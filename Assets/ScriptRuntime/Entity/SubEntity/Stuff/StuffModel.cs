using System;
using UnityEngine;

public class StuffModel {
    public int index;
    public int typeID;
    public string stuffName;
    public bool hasStuff;
    public StuffType stuffType;
    public int count;
    public int countMax;

    // gun
    public bool hasGun;
    public int gunTypeID;

    // Bullet
    public bool hasBuletBox;
    public int bulletBoxTypeID;

    // supply
    // 恢复血量
    public bool isReHP;
    public int reHPMax;

    // 恢复体力
    public bool isReStrength;
    public int reStrengthMax;
    // 背包里 显示的图片
    public Sprite Spr;

    public StuffModel() {
        hasStuff = false;
    }

    public void Clear() {
        hasStuff = false;
        typeID = -1;
    }
}
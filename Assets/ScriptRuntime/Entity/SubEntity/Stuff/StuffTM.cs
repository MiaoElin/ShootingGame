using UnityEngine;

[CreateAssetMenu(menuName = "TM/StuffTM", fileName = "StuffTM")]
public class StuffTM : ScriptableObject {
    public int typeID;
    public string stuffName;
    public StuffType stuffType;
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

    // stuff 的显示图片
    public Sprite stuffSpr;
}
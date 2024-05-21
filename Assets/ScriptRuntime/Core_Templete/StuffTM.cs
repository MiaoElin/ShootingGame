using UnityEngine;

[CreateAssetMenu(menuName = "TM/StuffTM", fileName = "StuffTM")]
public class StuffTM : ScriptableObject {
    public int typeID;
    public StuffType stuffType;
    public int countMax;

    // gun
    public bool isGun;
    public int gunTypeID;
    
    // Bullet
    public bool isBuletBox;
    public int bulletBoxTypeID;

    // supply
    // 恢复血量
    public bool isReHP;
    public int reHPMax;

    // 恢复体力
    public bool isReStrength;
    public int reStrengthMax;

    // stuff 的限制图片
    public Sprite stuffSpr;
}
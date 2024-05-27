using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PlayerStatus : MonoBehaviour {

    [SerializeField] Text txt_Hp;
    [SerializeField] Text txt_BullletCount;
    [SerializeField] Image img_BG;
    [SerializeField] Image img_Weapon;
    [SerializeField] Image img_HPBar;
    int hpMax;

    public bool isHurtEasing;
    public float hurtTime;
    public float hurtDuration;

    public Color bgNormalColor;
    public Color bgHurtColor;
    public Color hpBarNormalColor;
    public Color hpBarHurtColor;


    public void Ctor(int hpMax) {
        this.hpMax = hpMax;
        hurtTime = 0;
        hurtDuration = 1f;

        bgNormalColor = new Color((float)69 / 255, (float)69 / 255, (float)69 / 255, 1);
        bgHurtColor = new Color((float)61 / 255, (float)21 / 255, (float)21 / 255, (float)146 / 255);

        hpBarNormalColor = new Color((float)72 / 255, (float)106 / 255, (float)74 / 255, 1);
        hpBarHurtColor = new Color((float)106 / 255, (float)72 / 255, (float)74 / 255, 1);

        img_BG.color = bgNormalColor;
        img_HPBar.color = hpBarNormalColor;

    }

    public void Update_Status(int hp, int bulletCount, int bulletCountMax, Sprite current_Weapon, float dt) {
        txt_BullletCount.text = $"{bulletCount}/{bulletCountMax}";
        img_HPBar.fillAmount = (float)hp / hpMax;
        img_Weapon.sprite = current_Weapon;
        HurtEasing(dt);
    }

    public void EnterHurt() {
        isHurtEasing = true;
    }

    public void HurtEasing(float dt) {
        if (!isHurtEasing) {
            return;
        }
        if (hurtTime >= hurtDuration) {
            isHurtEasing = false;
            hurtTime = 0;
            img_BG.GetComponent<Image>().color = bgNormalColor;
            img_HPBar.GetComponent<Image>().color = hpBarNormalColor;
            img_BG.transform.localScale = Vector3.one;

        } else {
            img_BG.GetComponent<Image>().color = bgHurtColor;
            img_HPBar.GetComponent<Image>().color = hpBarHurtColor;
            var t = hurtTime / (hurtDuration / 3);
            var scale = Vector3.Lerp(Vector3.one, new Vector3(1.1f, 1.1f, 1.1f), t);
            img_BG.transform.localScale = scale;
            hurtTime += dt;

        }
    }

    public void SetNormal() {
    }

    internal void Close() {
        Destroy(gameObject);
    }
}
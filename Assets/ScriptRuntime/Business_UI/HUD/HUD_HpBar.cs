using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD_HpBar : MonoBehaviour {

    [SerializeField] Image hpBg;
    [SerializeField] Image hpBar;
    int hpMax;

    public void Ctor(int id, int hpMax) {
        this.hpMax = hpMax;
    }

    public void UpdateTick(int hp) {
        hpBar.fillAmount = (float)hp / hpMax;
    }

    internal void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    internal void SetForward(Vector3 forward) {
        transform.forward = forward;
    }
}
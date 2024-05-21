using UnityEngine;
using UnityEngine.UI;
using System;

public class Panel_Bag_Element : MonoBehaviour {

    [SerializeField] Button btn_grid;
    [SerializeField] Image spr_Stuff;
    public int index;
    public int typeID;
    public StuffType stuffType;
    public bool hasStuff;

    public void Ctor(Action action) {
        hasStuff = false;
        btn_grid.onClick.AddListener(() => {
            action.Invoke();
        });

    }

    public void Reuse() {
        hasStuff = false;
        spr_Stuff.gameObject.SetActive(false);
        btn_grid.GetComponentInChildren<Text>().text = "";
        btn_grid.image.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 75 / 255f);
    }

    public void SetGridHasStuff(Sprite spr, string name, int count) {
        hasStuff = true;
        spr_Stuff.gameObject.SetActive(true);
        spr_Stuff.sprite = spr;
        btn_grid.GetComponentInChildren<Text>().text = $"{name} X {count}";
        btn_grid.image.color = new Color(191 / 255f, 191 / 255f, 191 / 255f, 75 / 255f);
    }
}
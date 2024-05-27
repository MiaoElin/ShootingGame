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

    public void Ctor(Action<int> action) {
        hasStuff = false;
        btn_grid.onClick.AddListener(() => {
            action.Invoke(typeID);
        });

    }

    public void Reuse() {
        hasStuff = false;
        spr_Stuff.gameObject.SetActive(false);
        btn_grid.GetComponentInChildren<Text>().text = "";
        btn_grid.image.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 75 / 255f);
    }

    public void SetGridHasStuff(int typeID, Sprite spr, string name, int count) {
        hasStuff = true;
        this.typeID = typeID;
        spr_Stuff.gameObject.SetActive(true);
        spr_Stuff.sprite = spr;
        btn_grid.GetComponentInChildren<Text>().text = $"{name} X {count}";
        btn_grid.image.color = new Color(138 / 255f, 138 / 255f, 138 / 255f, 75 / 255f);
    }
}
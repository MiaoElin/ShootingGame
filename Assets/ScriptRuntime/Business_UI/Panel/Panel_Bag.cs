using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Panel_Bag : MonoBehaviour {

    [SerializeField] public Button btn_Supply;
    [SerializeField] public Button btn_Weapon;

    [SerializeField] Transform supply_Group;
    [SerializeField] Transform weapon_Group;
    public Transform currentGroup;

    [SerializeField] Panel_Bag_Element[] elements;
    [SerializeField] Panel_Bag_Element prefab;
    public int elementsCount;
    public Action OnClickGridHandle;

    public void Ctor() {
        elementsCount = 16;
        var GridMaxCountPerGroup = CommonConst.BAG_MAXCOUNT_PERGROUP;
        elements = new Panel_Bag_Element[16];

        // btn Click
        btn_Supply.onClick.AddListener(() => {
            SetCurrentGroup(supply_Group);
        });

        btn_Weapon.onClick.AddListener(() => {
            SetCurrentGroup(weapon_Group);
        });

        // 生成空格子
        for (int i = 0; i < elementsCount; i++) {
            if (i < GridMaxCountPerGroup) {
                currentGroup = supply_Group;
            } else if (i < GridMaxCountPerGroup * 2) {
                currentGroup = weapon_Group;
            }
            var element = GameObject.Instantiate(prefab, currentGroup);
            element.Ctor(OnClickGridHandle);
            element.Reuse();
            elements[i] = element;
        }
        SetCurrentGroup(supply_Group);

    }

    public void Init(int index, int count, string name, Sprite spr) {
        if (count != 0) {
            elements[index].SetGridHasStuff(spr, name, count);
        } else {
            elements[index].Reuse();
        }
    }

    public void SetCurrentGroup(Transform targetGroup) {
        this.currentGroup = targetGroup;
        HideAllGroup();
        currentGroup.gameObject.SetActive(true);
    }

    public void HideAllGroup() {
        supply_Group.gameObject.SetActive(false);
        weapon_Group.gameObject.SetActive(false);
    }
}
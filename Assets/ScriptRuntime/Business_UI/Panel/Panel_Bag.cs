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

    public Action OnClickBtn_SupplyHandle;
    public Action OnClickBtn_WeaponHandle;
    public Action OnClickGridHandle;

    public void Ctor() {
        elementsCount = 16;
        var GridMaxCountPerGroup = CommonConst.GRID_MAXCOUNT_PERGROUP;
        elements = new Panel_Bag_Element[16];

        // btn Click
        btn_Supply.onClick.AddListener(() => {
            // btn_Supply.image.sprite=
            OnClickBtn_SupplyHandle.Invoke();
        });

        btn_Weapon.onClick.AddListener(() => {
            OnClickBtn_WeaponHandle.Invoke();
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

    public void Init(int typeID) {
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
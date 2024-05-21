using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Panel_BagDomain {

    public static void Open(UIContext ctx) {
        var panel = ctx.uIRepo.Tryget<Panel_Bag>();
        if (panel == null) {
            ctx.asset.TryGetUI_Prefab(typeof(Panel_Bag).Name, out var prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_Bag>();
            panel.Ctor();
            panel.OnClickBtn_SupplyHandle = () => { };
            panel.OnClickBtn_WeaponHandle = () => { };
            panel.OnClickGridHandle = () => { };
            ctx.uIRepo.Add(typeof(Panel_Bag).Name, panel.gameObject);
            EventSystem.current.SetSelectedGameObject(panel.btn_Supply.gameObject);
        }
        // panel.Init();
        panel.gameObject.SetActive(true);
        // panel.btn_Supply.Select();
    }

    public static void Hide(UIContext ctx) {
        var paenl = ctx.uIRepo.Tryget<Panel_Bag>();
        paenl?.gameObject.SetActive(false);
    }
}
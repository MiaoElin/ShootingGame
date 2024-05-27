using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Panel_BagDomain {

    public static void Open(UIContext ctx, StuffComponent stuffs) {
        var panel = ctx.uIRepo.Tryget<Panel_Bag>();
        if (panel == null) {
            ctx.asset.TryGetUI_Prefab(typeof(Panel_Bag).Name, out var prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_Bag>();
            panel.OnClickGridHandle = (int typeID) => { ctx.eventCenter.UseStuff(typeID); };
            panel.Ctor();
            ctx.uIRepo.Add(typeof(Panel_Bag).Name, panel.gameObject);
            EventSystem.current.SetSelectedGameObject(panel.btn_Supply.gameObject);
        }
        // 遍历stuffs，赋值给背包里的每个格子
        stuffs.Foreach(stuff => {
            panel.Init(stuff.index, stuff.typeID, stuff.count, stuff.stuffName, stuff.Spr);
        });
        panel.gameObject.SetActive(true);
    }

    public static void Hide(UIContext ctx) {
        var paenl = ctx.uIRepo.Tryget<Panel_Bag>();
        paenl?.gameObject.SetActive(false);
    }
}
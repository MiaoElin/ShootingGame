using UnityEngine;

public static class Panel_BagDomain {

    public static void Open(UIContext ctx) {
        var paenl = ctx.uIRepo.Tryget<Panel_Bag>();
        if (paenl == null) {
            ctx.asset.TryGetUI_Prefab(typeof(Panel_Bag).Name, out var prefab);
            paenl = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_Bag>();
            paenl.Ctor();
            paenl.OnClickBtn_SupplyHandle = () => { };
            paenl.OnClickBtn_WeaponHandle = () => { };
            paenl.OnClickGridHandle = () => { };

            ctx.uIRepo.Add(typeof(Panel_Bag).Name, paenl.gameObject);
        }
        paenl.Init();
        paenl.gameObject.SetActive(true);
    }

    public static void Hide(UIContext ctx) {
        var paenl = ctx.uIRepo.Tryget<Panel_Bag>();
        paenl?.gameObject.SetActive(false);
    }
}
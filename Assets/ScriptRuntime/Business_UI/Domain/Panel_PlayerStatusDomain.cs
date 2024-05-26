using UnityEngine;

public static class Panel_PlayerStatusDomain {

    public static void Open(UIContext ctx, int hpMax) {
        var panel = ctx.uIRepo.Tryget<Panel_PlayerStatus>();
        if (panel == null) {
            ctx.asset.TryGetUI_Prefab(typeof(Panel_PlayerStatus).Name, out var prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_PlayerStatus>();
            panel.Ctor(hpMax);
            ctx.uIRepo.Add(typeof(Panel_PlayerStatus).Name, panel.gameObject);
        }
        // panel.Init(hp, bulletCount, bulletCountMax, currentWeapon);
    }

    public static void Close(UIContext ctx) {
        var panel = ctx.uIRepo.Tryget<Panel_PlayerStatus>();
        panel?.Close();
    }

    public static void Update(UIContext ctx, int hp, Sprite currentWeapon, int bulletCount, int bulletCountMax) {
        var panel = ctx.uIRepo.Tryget<Panel_PlayerStatus>();
        panel?.Init(hp, bulletCount, bulletCountMax, currentWeapon);
    }

    public static void EnterHurt(UIContext ctx) {
        var panel = ctx.uIRepo.Tryget<Panel_PlayerStatus>();
        panel?.EnterHurt();
    }
}
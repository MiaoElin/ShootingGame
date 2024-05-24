using UnityEngine;

public static class HUD_HpBarDomain {

    public static void Open(UIContext ctx, int id, int hpMax) {
        bool has = ctx.hpBarRepo.TryGet(id, out var hud);
        if (!has) {
            ctx.asset.TryGetUI_Prefab(typeof(HUD_HpBar).Name, out var prefab);
            hud = GameObject.Instantiate(prefab, ctx.worldCanvas.transform).GetComponent<HUD_HpBar>();
            hud.Ctor(id, hpMax);
            ctx.hpBarRepo.Add(id, hud);
        }
    }

    public static void Close(UIContext ctx, int id) {
        bool has = ctx.hpBarRepo.TryGet(id, out var hud);
        if (has) {
            GameObject.Destroy(hud.gameObject);
            ctx.hpBarRepo.Remove(id);
        }
    }

    public static void Update(UIContext ctx, int id, int hp, Vector3 pos, Vector3 forward) {
        bool has = ctx.hpBarRepo.TryGet(id, out var hud);
        if (has) {
            hud.SetPos(pos);
            hud.UpdateHpBar(hp);
            hud.SetForward(forward);
        }
    }
}
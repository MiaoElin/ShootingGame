using UnityEngine;

public static class Panel_LootSignalDomain {

    public static void Open(UIContext ctx, int id, Vector3 screenPos, Sprite spr, string lootName) {
        ctx.p_LootSignalRepo.Tryget(id, out var panel);
        if (panel == null) {
            ctx.asset.TryGetUI_Prefab(typeof(Panel_LootSignal).Name, out var prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_LootSignal>();
            panel.Ctor(spr, lootName);
            ctx.p_LootSignalRepo.Add(id, panel);
        }
        panel.SetPos(screenPos);
        panel.gameObject.SetActive(true);
    }


    public static void Hide(UIContext ctx, int id) {
        ctx.p_LootSignalRepo.Tryget(id, out var panel);
        panel?.gameObject.SetActive(false);
    }

    public static void Close(UIContext ctx, int id) {
        ctx.p_LootSignalRepo.Tryget(id, out var panel);
        GameObject.Destroy(panel.gameObject);
    }
}
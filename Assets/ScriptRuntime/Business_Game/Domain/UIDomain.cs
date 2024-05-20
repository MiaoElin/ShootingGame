using UnityEngine;

public static class UIDomain {

    public static void Panel_CrossHair_Open(GameContext ctx) {
        ctx.uIApp.Panel_CrossHair_Open();
    }

    public static void Panel_CrossHair_Hide(GameContext ctx) {
        ctx.uIApp.Panel_CrossHair_Hide();
    }

    public static void Panel_LootSignal_Open(GameContext ctx, int id, Vector3 pos, Sprite spr, string lootName) {
        ctx.uIApp.Panel_LootSignal_Open(id, pos, spr, lootName);
    }

    public static void Panel_LootSignal_Hide(GameContext ctx, int id) {
        ctx.uIApp.Panel_LootSignal_Hide(id);
    }

    public static void Panel_LootSignal_Close(GameContext ctx, int id) {
        ctx.uIApp.Panel_LootSignal_Close(id);
    }
}
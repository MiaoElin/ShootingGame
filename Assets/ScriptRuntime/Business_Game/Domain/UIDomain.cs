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

    public static void Panel_Bag_Open(GameContext ctx) {
        ctx.uIApp.Panel_Bag_Open(ctx.GetOwner().stuffCom);
    }

    public static void Panel_Bag_Hide(GameContext ctx) {
        ctx.uIApp.Panel_Bag_Hide();
    }

    public static void H_HpBar_Open(GameContext ctx, int id, int hpMax) {
        ctx.uIApp.H_HpBar_Open(id, hpMax);
    }

    public static void H_HpBar_Close(GameContext ctx, int id) {
        ctx.uIApp.H_HpBar_Close(id);
    }

    public static void H_HpBar_Update(GameContext ctx, int id, Vector3 pos, Vector3 forward) {
        ctx.uIApp.H_HpBar_Update(id, pos, forward);
    }
}
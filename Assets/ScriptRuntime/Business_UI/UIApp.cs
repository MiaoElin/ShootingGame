using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UIApp {

    UIContext ctx;

    public UIApp() {
        ctx = new UIContext();
    }

    public void Inject(AssetCore asset, Canvas screenCanvas, Canvas worldCanvas,EventCenter eventCenter) {
        ctx.Inject(asset, screenCanvas, worldCanvas,eventCenter);
    }

    #region  P_CrossHair
    public void Panel_CrossHair_OpenTPS() {
        Panel_CrossHairDomain.Open_TPS(ctx);
    }

    public void Panel_CrossHair_OpenFPS() {
        Panel_CrossHairDomain.Open_FPS(ctx);
    }

    public void Panel_CrossHair_Hide() {
        Panel_CrossHairDomain.Hide(ctx);
    }


    #endregion

    #region P_LootSignal
    public void Panel_LootSignal_Open(int id, Vector3 pos, Sprite spr, string lootName) {
        Panel_LootSignalDomain.Open(ctx, id, pos, spr, lootName);
    }

    public void Panel_LootSignal_Hide(int id) {
        Panel_LootSignalDomain.Hide(ctx, id);
    }

    public void Panel_LootSignal_Close(int id) {
        Panel_LootSignalDomain.Close(ctx, id);
    }
    #endregion

    #region P_Bag
    public void Panel_Bag_Open(StuffComponent stuffCom) {
        Panel_BagDomain.Open(ctx, stuffCom);
    }

    public void Panel_Bag_Hide() {
        Panel_BagDomain.Hide(ctx);
    }
    #endregion

    #region  P_PlayerStatus
    public void Panel_PlayerStatus_Open(int hpMax) {
        Panel_PlayerStatusDomain.Open(ctx, hpMax);
    }

    public void Panel_PlayerStatus_Close() {
        Panel_PlayerStatusDomain.Close(ctx);
    }

    public void Panel_PlayerStatus_Update(int hp, Sprite currentWeapon, int bulletCount, int bulletCountMax, float dt) {
        Panel_PlayerStatusDomain.Update_Status(ctx, hp, currentWeapon, bulletCount, bulletCountMax, dt);
    }

    public void Panel_PlayerStatus_EnterHurt() {
        Panel_PlayerStatusDomain.EnterHurt(ctx);
    }

    #endregion

    #region H_HpBar
    public void H_HpBar_Open(int id, int hpMax) {
        HUD_HpBarDomain.Open(ctx, id, hpMax);
    }

    internal void H_HpBar_Update(int id, int hp, Vector3 pos, Vector3 forward) {
        HUD_HpBarDomain.Update(ctx, id, hp, pos, forward);
    }

    public void H_HpBar_Close(int id) {
        HUD_HpBarDomain.Close(ctx, id);
    }
    #endregion


}

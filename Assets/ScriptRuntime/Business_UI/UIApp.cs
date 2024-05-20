using UnityEngine;
using UnityEngine.AddressableAssets;

public class UIApp {

    UIContext ctx;

    public UIApp() {
        ctx = new UIContext();
    }

    public void Inject(AssetCore asset, Canvas screenCanvas) {
        ctx.Inject(asset, screenCanvas);
    }

    public void Panel_CrossHair_Open() {
        Panel_CrossHairDomain.Open(ctx);
    }

    public void Panel_CrossHair_Hide() {
        Panel_CrossHairDomain.Hide(ctx);
    }

    public void Panel_LootSignal_Open(int id, Vector3 pos, Sprite spr, string lootName) {
        Panel_LootSignalDomain.Open(ctx, id, pos, spr, lootName);
    }

    public void Panel_LootSignal_Hide(int id) {
        Panel_LootSignalDomain.Hide(ctx, id);
    }

    public void Panel_LootSignal_Close(int id) {
        Panel_LootSignalDomain.Close(ctx, id);
    }

}

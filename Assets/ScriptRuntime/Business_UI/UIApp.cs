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
}
using UnityEngine;

public static class Panel_CrossHairDomain {

    public static void Open_TPS(UIContext ctx) {
        string name = typeof(Panel_CrossHair).Name;
        var panel = ctx.uIRepo.Tryget<Panel_CrossHair>();
        if (panel == null) {
            ctx.asset.TryGetUI_Prefab(name, out var prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_CrossHair>();
            ctx.uIRepo.Add(name, panel.gameObject);
        }
        panel.Show_TPS();
    }


    public static void Hide_TPS(UIContext ctx) {
        var panel = ctx.uIRepo.Tryget<Panel_CrossHair>();
        panel?.Hide_TPS();
    }

    public static void Open_FPS(UIContext ctx) {
        string name = typeof(Panel_CrossHair).Name;
        var panel = ctx.uIRepo.Tryget<Panel_CrossHair>();
        if (panel == null) {
            ctx.asset.TryGetUI_Prefab(name, out var prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_CrossHair>();
            ctx.uIRepo.Add(name, panel.gameObject);
        }
        panel.Show_FPS();
    }

    public static void Hide_FPS(UIContext ctx) {
        var panel = ctx.uIRepo.Tryget<Panel_CrossHair>();
        panel?.Hide_FPS();
    }
}
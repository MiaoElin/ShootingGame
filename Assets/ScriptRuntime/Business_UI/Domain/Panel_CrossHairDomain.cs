using UnityEngine;

public static class Panel_CrossHairDomain {

    public static void Open(UIContext ctx) {
        string name = typeof(Panel_CrossHair).Name;
        var panel = ctx.uIRepo.Tryget<Panel_CrossHair>();
        if (panel == null) {
            ctx.asset.TrygeUI_Prefab(name, out var prefab);
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_CrossHair>();
            ctx.uIRepo.Add(name, panel.gameObject);
        }
        panel.Show();
    }

    public static void Hide(UIContext ctx) {
        var panel = ctx.uIRepo.Tryget<Panel_CrossHair>();
        panel?.Hide();
    }
}
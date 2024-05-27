using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class UIContext {

    public AssetCore asset;
    public UIRepo uIRepo;
    public HpBarRepo hpBarRepo;
    public EventCenter eventCenter;
    public P_LootSignalRepo p_LootSignalRepo;
    public Canvas screenCanvas;
    public Canvas worldCanvas;

    public UIContext() {
        uIRepo = new UIRepo();
        hpBarRepo = new HpBarRepo();
        p_LootSignalRepo = new P_LootSignalRepo();
    }



    public void Inject(AssetCore asset, Canvas screenCanvas, Canvas worldCanvas, EventCenter eventCenter) {
        this.asset = asset;
        this.screenCanvas = screenCanvas;
        this.worldCanvas = worldCanvas;
        this.eventCenter = eventCenter;
    }


}
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class UIContext {

    public AssetCore asset;
    public UIRepo uIRepo;
    public EventCenter eventCenter;
    public P_LootSignalRepo p_LootSignalRepo;
    public Canvas screenCanvas;

    public UIContext() {
        uIRepo = new UIRepo();
        p_LootSignalRepo = new P_LootSignalRepo();
    }

    public void Inject(AssetCore asset, Canvas screenCanvas) {
        this.asset = asset;
        this.screenCanvas = screenCanvas;
    }


}
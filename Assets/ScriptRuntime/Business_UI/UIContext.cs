using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class UIContext {

    public AssetCore asset;
    public UIRepo uIRepo;
    public Canvas screenCanvas;

    public UIContext() {
        uIRepo = new UIRepo();
    }

    public void Inject(AssetCore asset, Canvas screenCanvas) {
        this.asset = asset;
        this.screenCanvas = screenCanvas;
    }

}
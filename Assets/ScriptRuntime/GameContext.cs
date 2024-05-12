using UnityEngine;

public class GameContext {

    public InputEntity input;

    // Core
    public AssetCore asset;
    // Service
    public IDService iDService;

    public GameContext() {
        input = new InputEntity();
    }
}
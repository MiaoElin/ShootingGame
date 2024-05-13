using UnityEngine;

public class GameContext {

    public float restTime;

    // === Entity ===
    public InputEntity input;
    public CameraEntity camreEntity;

    // === Core ===
    public AssetCore asset;
    public UIApp uIApp;

    // === Service ===
    public IDService iDService;
    public PoolService poolService;
    // === Repo ===
    public RoleRepo roleRepo;


    // === Owner ===
    public int ownerID;

    // === Fsm ===
    public GameFsmComponent fsm;

    public GameContext() {
        // entity
        input = new InputEntity();
        camreEntity = new CameraEntity();
        // core
        asset = new AssetCore();
        roleRepo = new RoleRepo();
        uIApp = new UIApp();
        // Service
        iDService = new IDService();
        poolService = new PoolService();
        // componet
        fsm = new GameFsmComponent();

    }

    public void Inject(Camera camera, Canvas screenCanvas) {
        this.camreEntity.camera = camera;
        camreEntity.Ctor();
        uIApp.Inject(asset, screenCanvas);
    }

    public RoleEntity GetOwner() {
        roleRepo.Tryget(ownerID, out var role);
        return role;
    }
}
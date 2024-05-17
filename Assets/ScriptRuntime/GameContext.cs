using UnityEngine;
using Cinemachine;
public class GameContext {

    public float restTime;

    // === Entity ===
    public InputEntity input;
    // === Camera ===
    public CinemachineFreeLook mainCamera;

    // === Core ===
    public AssetCore asset;
    public UIApp uIApp;
    public SoundCore soundCore;

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
        // core
        asset = new AssetCore();
        roleRepo = new RoleRepo();
        uIApp = new UIApp();
        soundCore = new SoundCore();
        // Service
        iDService = new IDService();
        poolService = new PoolService();
        // componet
        fsm = new GameFsmComponent();

    }

    public void Inject(CinemachineFreeLook camera, Canvas screenCanvas) {
        this.mainCamera = camera;
        uIApp.Inject(asset, screenCanvas);
    }

    public RoleEntity GetOwner() {
        roleRepo.Tryget(ownerID, out var role);
        return role;
    }
}
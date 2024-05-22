using UnityEngine;
using Cinemachine;
public class GameContext {

    public float restTime;

    // === Entity ===
    public InputEntity input;
    // === Camera ===
    public CameraEntity cameraEntity;
    // === Core ===
    public AssetCore asset;
    public UIApp uIApp;
    public SoundCore soundCore;

    // === Service ===
    public IDService iDService;
    public PoolService poolService;

    // === Repo ===
    public RoleRepo roleRepo;
    public LootRepo lootRepo;
    public PropRepo propRepo;

    // === Owner ===
    public int ownerID;

    // === Fsm ===
    public GameFsmComponent fsm;

    public GameContext() {
        // entity
        input = new InputEntity();
        cameraEntity = new CameraEntity();
        // core
        asset = new AssetCore();
        uIApp = new UIApp();
        soundCore = new SoundCore();

        // Repo
        roleRepo = new RoleRepo();
        lootRepo = new LootRepo();
        propRepo = new PropRepo();

        // Service
        iDService = new IDService();
        poolService = new PoolService();
        // componet
        fsm = new GameFsmComponent();

    }

    public void Inject(CinemachineFreeLook normalCamera, CinemachineFreeLook shootCamera, Camera currentCamera, Canvas screenCanvas) {
        cameraEntity.Inject(currentCamera, normalCamera, shootCamera);
        uIApp.Inject(asset, screenCanvas);
    }

    public RoleEntity GetOwner() {
        roleRepo.Tryget(ownerID, out var role);
        return role;
    }
}
using UnityEngine;

public class GameContext {

    public float restTime;

    // === Entity ===
    public InputEntity input;
    public CameraEntity camreEntity;

    // === Core ===
    public AssetCore asset;

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
        // Service
        iDService = new IDService();
        poolService = new PoolService();
        // componet
        fsm = new GameFsmComponent();

    }

    public void Inject(Camera camera) {
        this.camreEntity.camera = camera;
        camreEntity.Ctor();
    }

    public RoleEntity GetOwner() {
        roleRepo.Tryget(ownerID, out var role);
        return role;
    }
}
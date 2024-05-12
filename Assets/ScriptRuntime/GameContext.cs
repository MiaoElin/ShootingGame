using UnityEngine;

public class GameContext {

    public float restTime;

    public InputEntity input;

    // Core
    public AssetCore asset;

    // Service
    public IDService iDService;

    // === Repo ===
    public RoleRepo roleRepo;

    // === Owner ===
    public int ownerID;

    // Fsm
    public GameFsmComponent fsm;

    public GameContext() {
        input = new InputEntity();
        asset = new AssetCore();
        roleRepo = new RoleRepo();
        iDService = new IDService();

        fsm = new GameFsmComponent();
    }

    public RoleEntity GetOwner() {
        roleRepo.Tryget(ownerID, out var role);
        return role;
    }
}
using UnityEngine;

public class GameContext {

    public InputEntity input;

    // Core
    public AssetCore asset;

    // Service
    public IDService iDService;

    // === Repo ===
    public RoleRepo roleRepo;

    // === Owner ===
    public int ownerID;

    public GameContext() {
        input = new InputEntity();
        asset = new AssetCore();
        roleRepo = new RoleRepo();
        iDService = new IDService();
    }

    public RoleEntity GetOwner() {
        roleRepo.Tryget(ownerID, out var role);
        return role;
    }
}
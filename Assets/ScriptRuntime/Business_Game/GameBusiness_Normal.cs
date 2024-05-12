using UnityEngine;

public static class GameBusiness_Normal {

    public static void Enter(GameContext ctx) {
        var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, 0, 0));
        ctx.ownerID = owner.id;
    }

    public static void Tick(GameContext ctx, float dt) {
        var owner = ctx.GetOwner();
        owner.Move(ctx.input.moveAxis);
        owner.Anim_Run();
    }
}
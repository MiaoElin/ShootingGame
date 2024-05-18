using UnityEngine;

public static class CameraDomain {

    public static void SetFollowAndLookAt(GameContext ctx) {
        ctx.cameraEntity.SetFollow(ctx.GetOwner().transform);
        ctx.cameraEntity.SetLookAt(ctx.GetOwner().lookAtPoint);
    }

    public static void EnterNormal(GameContext ctx) {
        ctx.cameraEntity.EnterNormal();
        SetFollowAndLookAt(ctx);
    }

    public static void EnterShoot(GameContext ctx) {
        ctx.cameraEntity.EnterShoot();
        SetFollowAndLookAt(ctx);
    }
}
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

    public static void MouseAxisTick(GameContext ctx) {
        var camera = ctx.cameraEntity.currentCam;
        var axisSpeed = ctx.cameraEntity.GetCameraAxisSpeed();
        if (ctx.input.isMouseLeftDown) {
            camera.m_XAxis.m_MaxSpeed = axisSpeed.x;
            camera.m_YAxis.m_MaxSpeed = axisSpeed.y;
        } else if (ctx.input.isMouseLeftUp) {
            camera.m_XAxis.m_MaxSpeed = 0;
            camera.m_YAxis.m_MaxSpeed = 0;
        }
    }
}
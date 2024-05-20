using UnityEngine;

public static class GameBusiness_OpenBag {

    public static void Tick(GameContext ctx) {
        var fsm = ctx.fsm;
        if (fsm.isEnterOpenBag) {
            fsm.isEnterOpenBag = false;
            // Hide CrossHair
            UIDomain.Panel_CrossHair_Hide(ctx);
            // Open Curcor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Close CameraRotation
            CameraDomain.CloseRotation(ctx);
            // Open Bag UI
            UIDomain.Panel_Bag_Open(ctx);
            return;
        }

        var owner = ctx.GetOwner();
        if (owner.isBagOpen) {
            if (ctx.input.isBagkeyDown) {
                owner.isBagOpen = false;
                // 锁定光标
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                // 打开相机旋转
                CameraDomain.OpenRotation(ctx);
                // 关闭背包UI
                UIDomain.Panel_Bag_Hide(ctx);
                // 进入normal
                fsm.EnterNormal();
            }
        }
    }
}
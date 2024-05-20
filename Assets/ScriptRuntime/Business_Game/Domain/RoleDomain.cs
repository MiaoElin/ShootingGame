using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        var role = GameFactory.Role_Spawn(ctx, typeID, pos);
        ctx.roleRepo.Add(role);
        return role;
    }

    public static void Move(GameContext ctx, RoleEntity role, float dt) {
        if (role.moveType == MoveType.ByInput) {
            Vector3 dir = ctx.input.moveAxis;
            role.Move(dir, dt);
            // animator
            role.Anim_Run();
            // sfx
            if (dir != Vector3.zero) {
                SFXDomain.Role_Walk_Play(ctx);
            } else {
                SFXDomain.Role_Walk_Stop(ctx);
            }
        }
    }

    public static void SetForward_Normal(GameContext ctx, RoleEntity role, float dt) {
        role.SetForward_Normal(ctx.input.moveAxis, ctx.cameraEntity.GetPos(), dt);
    }

    public static void SetForward_Shoot(GameContext ctx, RoleEntity role) {
        role.SetForward_Shoot(ctx.cameraEntity.GetPos());
    }

    public static void Jump(RoleEntity role) {
        bool isJump = role.IsJump();
        if (isJump) {
            // anim
            role.Anim_Jump();
            // sfx
            // vfx
        }
    }

    public static void Falling(RoleEntity role, float dt) {
        role.Falling(dt);
    }

    // Ground Check
    public static void GroundCheck(GameContext ctx, RoleEntity role) {
        if (role.Velocity().y > 0) {
            return;
        }
        var layerMask = 1 << LayerMaskConst.GROUND;
        var quat = Quaternion.LookRotation(role.GetForward(), Vector3.up);
        Collider[] hits = Physics.OverlapBox(role.Pos(), new Vector3(0.6f, 0.1f, 0.3f), quat, layerMask);

        if (hits.Length != 0) {
            if (!role.isInGround) {
                SFXDomain.Role_EnterGroud(ctx);
            }
            role.isInGround = true;
        } else {
            role.isInGround = false;
        }
    }

    // 找最近的Loot
    public static void SearchLoot(GameContext ctx, RoleEntity role, out LootEntity nearlyLoot) {
        var lootLen = ctx.lootRepo.TakeAll(out var allLoots);
        nearlyLoot = null;
        float nearlyDistance = Mathf.Pow(CommonConst.OWNER_SEARCHRANGE, 2);
        for (int i = 0; i < lootLen; i++) {
            var loot = allLoots[i];
            // 判断是不是在搜索范围
            var isInRange = PureFuction.IsPointInRange(role.Pos(), loot.Pos(), CommonConst.OWNER_SEARCHRANGE, out var distance);
            if (isInRange) {
                // 打开lootSignal
                Vector2 pos = Camera.main.WorldToScreenPoint(loot.Pos());
                UIDomain.Panel_LootSignal_Open(ctx, loot.id, pos + Vector2.up * 100, loot.signalSpr, loot.lootName);
                if (distance <= nearlyDistance) {
                    nearlyDistance = distance;
                    nearlyLoot = loot;
                }
            } else {
                UIDomain.Panel_LootSignal_Hide(ctx, loot.id);
            }
        }
    }

    public static void PickUpLoot(GameContext ctx, RoleEntity role, LootEntity nearlyLoot) {
        if (role.isPickKeyDown && nearlyLoot) {
            Debug.Log("In");
            // 生成stuff
            // 添加进背包
            // 销毁loot
        }
    }


}
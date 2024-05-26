using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Vector3 rot, Vector3 scale, Ally ally) {
        var role = GameFactory.Role_Spawn(ctx, typeID, pos, rot, scale, ally);
        ctx.roleRepo.Add(role);
        return role;
    }

    public static void Unspawn(GameContext ctx, RoleEntity role) {
        ctx.roleRepo.Remove(role);
        role.gameObject.SetActive(false);
        ctx.poolService.ReTurnRole(role);
    }

    public static void Move(GameContext ctx, RoleEntity role, float dt) {
        if (role.moveType == MoveType.ByInput) {
            Vector3 dir = ctx.input.moveAxis;
            role.Move(dir, dt);
            // animator
            role.Anim_Run();
            // sfx
            if (dir != Vector3.zero) {
                if (role.isSlowKeyDown) {
                    SFXDomain.Role_Walk_Play(ctx);
                } else {
                    SFXDomain.Role_Run_Play(ctx);
                }
            } else {
                SFXDomain.Role_Run_Stop(ctx);
                SFXDomain.Role_Walk_Stop(ctx);
            }
        } else if (role.moveType == MoveType.ByAI) {

            // 判断目标是否在视线范围 这里的目标是owner
            var target = ctx.GetOwner();
            if (role.hasTarget) {
                Check_Touch(role, target, dt);
                if (!role.isArrivedTarget) {
                    role.Move_To(target.Pos(), dt);
                    // anim
                    role.Anim_Run();
                    return;
                }
            }

            bool isInRange = IsInViewRange(role, target);
            if (isInRange) {
                role.hasTarget = true;
            }

        }
    }

    public static bool IsInViewRange(RoleEntity role, RoleEntity target) {

        // -是否在viewRange里
        bool isinViewRange = PureFuction.IsPointInRange(role.Pos(), target.Pos(), role.viewRange);
        if (isinViewRange) {

            // 从头顶发射射线，判断有没有障碍物
            Vector3 targetDir = target.Pos() - role.Pos();
            var hasHinder = Physics.Raycast(role.Pos() + Vector3.up * role.height, targetDir);
            if (hasHinder) {
                return false;
            }

            // -是否在视线角度内
            Quaternion qutLeft = Quaternion.AngleAxis(-CommonConst.MONSTER_HALF_VIEWANGLW, Vector3.up);
            Vector3 viewLeft = qutLeft * role.body.transform.forward;
            float angle = Vector3.SignedAngle(viewLeft, targetDir, Vector3.up);
            if (angle < 0) {
                angle = 360 - angle; //适用于viewAngle大于180的情况
            }
            if (angle >= 0 && angle <= CommonConst.MONSTER_HALF_VIEWANGLW * 2) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    public static bool Check_Touch(RoleEntity monster, RoleEntity owner, float dt) {
        Vector3 dir = owner.Pos() - monster.Pos();
        RaycastHit[] hits = Physics.RaycastAll(monster.Pos() + Vector3.up * 0.1f, dir.normalized, 2f);
        monster.isArrivedTarget = false;
        foreach (var hit in hits) {
            if (hit.collider.tag == "Role") {
                var role = hit.collider.GetComponentInParent<RoleEntity>();
                if (role.ally != monster.ally) {
                    monster.isArrivedTarget = true;
                }
            }
        }
        return monster.isArrivedTarget;
    }

    public static void Monster_Hit(GameContext ctx, RoleEntity role, float dt) {
        if (role.ally == Ally.Monster) {
            if (!role.isArrivedTarget) {
                return;
            }
            // 开始攻击
            var owner = ctx.GetOwner();
            // anim
            role.Anim_Attack();
            // 攻击逻辑
            // 动画播到攻击的地方才扣血
            ref var attackTime = ref role.attackTime;
            var before_attackDuration = role.before_attackDuration;
            var after_attackDuration = role.after_attackDuration;
            if (attackTime >= before_attackDuration && !role.hasAttack) {
                role.hasAttack = true;
                owner.hp -= role.attackDamage;
                UIDomain.Panel_PlayerStatus_EnterHurt(ctx);
            } else if (attackTime >= after_attackDuration) {
                role.hasAttack = false;
                attackTime = 0;
            }
            attackTime += dt;
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
            role.isPickKeyDown = false;
            var stuffTypeIDs = nearlyLoot.stuffTypeIDs;
            var stuffCounts = nearlyLoot.stuffCount;
            // Debug.Log(Time.frameCount + ":" + nearlyLoot.typeID);
            for (int i = 0; i < stuffTypeIDs.Count; i++) {
                var typeID = stuffTypeIDs[i];
                // 生成stuff
                var stuff = GameFactory.Stuff_Create(ctx, typeID, stuffCounts[i]);
                // 添加进背包
                int surplusCount = role.stuffCom.Add(stuff);
                if (surplusCount == 0) {
                    // 添加成功 销毁loot
                    LootDomain.Unspawn(ctx, nearlyLoot);
                    UIDomain.Panel_LootSignal_Close(ctx, nearlyLoot.id);
                    // SFX 
                    SFXDomain.Role_Pick(ctx);

                } else {
                    if (surplusCount == stuff.count) {
                        // 格子满了
                        Debug.Log("格子满了");
                    } else {
                        Debug.Log($"格子满了,成功添加了{stuff.count - surplusCount}个");
                    }
                }
            }
        }
    }

    public static void ShootBullet(GameContext ctx, RoleEntity role) {
        var gun = role.gun;
        if (gun != null) {
            // 从屏幕中心发射射线
            var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            var layermask = 1 << 6;
            var hit = Physics.Raycast(ray, out var raycastHit, gun.shootRang, layermask);
            // 显示准点光源
            if (ctx.input.isMouseLeftUp) {
                ctx.input.isMouseLeftUp = false;
                // Anim
                role.Anim_Shoot();
                // SFX
                SFXDomain.Gun_Shoot(ctx);
                // 生成子弹
                var bullet = BulletDomain.Spawn(ctx, gun.bulletTypeID, gun.launchPoint.position, role.ally);
                if (hit) {
                    // 设置子弹的dir
                    bullet.dir = raycastHit.point - gun.launchPoint.position;
                } else {
                    Vector3 endPoint = ray.origin + ray.direction * gun.shootRang;
                    bullet.dir = endPoint - bullet.Pos();
                }
            }
        }
    }

    public static void UpdateHpBar(GameContext ctx, RoleEntity role) {
        UIDomain.H_HpBar_Update(ctx, role.id, role.hp, role.Pos() + (role.height + CommonConst.ROLE_HEADOFFSET) * Vector3.up, ctx.cameraEntity.GetForward());
    }

}
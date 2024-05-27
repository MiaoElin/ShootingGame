using UnityEngine;

public static class BulletDomain {

    public static BulletEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Ally ally) {
        var bullet = GameFactory.Bullet_Spawn(ctx, typeID, pos, ally);
        ctx.bulletRepo.Add(bullet);
        return bullet;
    }

    public static void Unspawn(GameContext ctx, BulletEntity bullet) {
        ctx.bulletRepo.Remove(bullet);
        GameObject.Destroy(bullet.gameObject);
    }

    public static void Move(BulletEntity bullet, float dt) {
        if (bullet.bulletMoveType == BulletMoveType.ByLine) {
            bullet.Move(bullet.dir, dt);
        }
    }

    public static void CheckCollision(BulletEntity bullet, float dt) {
        var layerMask = 1 << 6;
        Ray ray = new Ray(bullet.Pos(), bullet.GetForward());
        RaycastHit[] hits = Physics.RaycastAll(ray, bullet.moveSpeed * dt, layerMask);
        for (int i = 0; i < hits.Length; i++) {
            var hit = hits[i];
            var role = hit.collider.gameObject.GetComponentInParent<RoleEntity>();
            Debug.Log(role.ally);
            if (role.isDead) {
                continue;
            }
            if (role.ally != bullet.ally) {
                role.hp -= bullet.damage;
                Debug.Log(role.hp);
                // anim
                role.Anim_Hurt();
                if (role.hp <= 0) {
                    role.isDead = true;
                }
            }
        }
    }
}
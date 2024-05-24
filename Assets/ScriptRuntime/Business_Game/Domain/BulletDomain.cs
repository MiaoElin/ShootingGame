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
        bool hitRole = Physics.Raycast(ray, out RaycastHit hit, bullet.moveSpeed * dt, layerMask);
        if (hitRole) {
            bullet.isDead = true;
            var role = hit.collider.gameObject.GetComponentInParent<RoleEntity>();
            if (role.ally != bullet.ally) {
                role.hp -= bullet.damage;
                if (role.hp <= 0) {
                    role.isDead = true;
                }
            }
        }

        // var roleLayer = 1 << 6;
        // Vector3 center = bullet.Pos();
        // Quaternion qut = Quaternion.LookRotation(bullet.GetForward(), Vector3.up);
        // Collider[] others = Physics.OverlapBox(center, bullet.halfExtents, qut, roleLayer);

        // if (others.Length > 0) {
        //     bullet.isDead = true;
        // }
        // foreach (var other in others) {
        //     Debug.Log(other.gameObject.tag);
        //     if (other.gameObject.tag == "Role") {
        //         var role = other.gameObject.GetComponentInParent<RoleEntity>();
        //         if (role.ally != bullet.ally) {
        //             Debug.Log(role.hp);
        //             role.hp -= bullet.damage;
        //             if (role.hp <= 0) {
        //                 role.isDead = true;
        //             }
        //         }
        //     }
        // }
    }
}
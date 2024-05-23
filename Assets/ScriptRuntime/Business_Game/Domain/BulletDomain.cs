using UnityEngine;

public static class BulletDomain {

    public static BulletEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Ally ally) {
        var bullet = GameFactory.Bullet_Spawn(ctx, typeID, pos, ally);
        ctx.bulletRepo.Add(bullet);
        return bullet;
    }

    public static void Unspawn(GameContext ctx, BulletEntity bullet) {
        ctx.bulletRepo.Remove(bullet);
        ctx.poolService.ReturnBullet(bullet);
    }
}
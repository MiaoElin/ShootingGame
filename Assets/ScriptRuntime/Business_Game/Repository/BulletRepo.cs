using UnityEngine;
using System.Collections.Generic;

public class BulletRepo {

    Dictionary<int, BulletEntity> all;
    BulletEntity[] temp;

    public BulletRepo() {
        all = new Dictionary<int, BulletEntity>();
        temp = new BulletEntity[1024];
    }

    public void Add(BulletEntity bullet) {
        all.Add(bullet.id, bullet);
    }

    public void Remove(BulletEntity bullet) {
        all.Remove(bullet.id);
    }

    public bool Tryget(int id, out BulletEntity bullet) {
        return all.TryGetValue(id, out bullet);
    }

    public int TakeAll(out BulletEntity[] allBullet) {
        if (temp.Length < all.Count) {
            temp = new BulletEntity[(int)(all.Count * 1.5f)];
        }
        all.Values.CopyTo(temp, 0);
        allBullet = temp;
        return all.Count;
    }
}
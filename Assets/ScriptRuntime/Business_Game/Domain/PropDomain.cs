using UnityEngine;

public static class PropDomain {

    public static PropEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Vector3 rot, Vector3 scale) {
        var prop = GameFactory.Prop_Spawn(ctx, typeID, pos, rot, scale);
        ctx.propRepo.Add(prop);
        return prop;
    }

}
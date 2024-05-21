using UnityEngine;

public static class StuffDomain {

    public static StuffModel Spawn(GameContext ctx, int typeID, int count) {
        return GameFactory.Stuff_Create(ctx, typeID, count);
    }
}
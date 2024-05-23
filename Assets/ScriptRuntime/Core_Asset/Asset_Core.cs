using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AssetCore {

    Dictionary<string, GameObject> entities;
    AsyncOperationHandle entityPtr;

    Dictionary<string, GameObject> allUI_Prefab;
    public AsyncOperationHandle uiPrefabPtr;

    Dictionary<int, RoleTM> roleTMs;
    AsyncOperationHandle roleTMPtr;

    Dictionary<int, LootTM> lootTMs;
    AsyncOperationHandle lootTMPtr;

    Dictionary<int, PropTM> propTMs;
    AsyncOperationHandle propTMPtr;

    Dictionary<int, GunTM> gunTMs;
    AsyncOperationHandle gunTMPtr;

    Dictionary<int, BulletTM> bulletTMs;
    AsyncOperationHandle bulletPtr;

    Dictionary<int, StuffTM> stuffTMs;
    AsyncOperationHandle stuffPtr;

    Dictionary<int, TerrainTM> terrainTMs;
    AsyncOperationHandle terrainPtr;

    Dictionary<int, MapTM> mapTMs;
    AsyncOperationHandle mapTMPtr;

    public ConfigTM configTM;
    AsyncOperationHandle configPtr;


    public AssetCore() {
        entities = new Dictionary<string, GameObject>();
        allUI_Prefab = new Dictionary<string, GameObject>();
        roleTMs = new Dictionary<int, RoleTM>();
        lootTMs = new Dictionary<int, LootTM>();
        propTMs = new Dictionary<int, PropTM>();
        gunTMs = new Dictionary<int, GunTM>();
        bulletTMs = new Dictionary<int, BulletTM>();
        stuffTMs = new Dictionary<int, StuffTM>();
        terrainTMs = new Dictionary<int, TerrainTM>();
        mapTMs = new Dictionary<int, MapTM>();
    }

    public void LoadAll() {
        {
            var handle = Addressables.LoadAssetsAsync<GameObject>("Entities", null);
            entityPtr = handle;
            var list = handle.WaitForCompletion();
            foreach (var prefab in list) {
                entities.Add(prefab.name, prefab);
            }
        }
        {
            var handle = Addressables.LoadAssetsAsync<RoleTM>("RoleTM", null);
            roleTMPtr = handle;
            var list = handle.WaitForCompletion();
            foreach (var tm in list) {
                roleTMs.Add(tm.typeId, tm);
            }
        }
        {
            var ptr = Addressables.LoadAssetsAsync<GameObject>("UI", null);
            uiPrefabPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var prefab in list) {
                allUI_Prefab.Add(prefab.name, prefab);
            }
        }
        {
            var ptr = Addressables.LoadAssetAsync<ConfigTM>("ConfigTM");
            configPtr = ptr;
            configTM = ptr.WaitForCompletion();
        }
        {
            var ptr = Addressables.LoadAssetsAsync<LootTM>("TM_Loot", null);
            lootTMPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                lootTMs.Add(tm.typeID, tm);
            }
        }
        {
            var ptr = Addressables.LoadAssetsAsync<PropTM>("TM_Prop", null);
            propTMPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                propTMs.Add(tm.typeID, tm);
            }
        }
        {
            var ptr = Addressables.LoadAssetsAsync<GunTM>("GunTM", null);
            gunTMPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                gunTMs.Add(tm.typeID, tm);
            }
        }
        {
            var ptr = Addressables.LoadAssetsAsync<BulletTM>("TM_Bullet", null);
            bulletPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                bulletTMs.Add(tm.typeID, tm);
            }
        }
        {
            var ptr = Addressables.LoadAssetsAsync<StuffTM>("StuffTM", null);
            stuffPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                stuffTMs.Add(tm.typeID, tm);
            }
        }
        {
            var ptr = Addressables.LoadAssetsAsync<TerrainTM>("TM_Terrain", null);
            terrainPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                terrainTMs.Add(tm.typeID, tm);
            }
        }
        {
            var ptr = Addressables.LoadAssetsAsync<MapTM>("TM_Map", null);
            mapTMPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                mapTMs.Add(tm.stageID, tm);
            }
        }

    }

    public void Unload() {
        Release(entityPtr);
        Release(roleTMPtr);
        Release(uiPrefabPtr);
        Release(configPtr);
        Release(lootTMPtr);
        Release(gunTMPtr);
        Release(bulletPtr);
        Release(stuffPtr);
        Release(terrainPtr);
        Release(mapTMPtr);
        Release(propTMPtr);
    }

    public void Release(AsyncOperationHandle ptr) {
        if (ptr.IsValid()) {
            Addressables.Release(ptr);
        }
    }

    public bool TryGetEntity_Prefab(string name, out GameObject prefab) {
        return entities.TryGetValue(name, out prefab);
    }

    public bool TryGetRoleTM(int typeID, out RoleTM tm) {
        return roleTMs.TryGetValue(typeID, out tm);
    }

    public bool TryGetUI_Prefab(string name, out GameObject ui) {
        return allUI_Prefab.TryGetValue(name, out ui);
    }

    public bool TryGetLootTM(int typeID, out LootTM tm) {
        return lootTMs.TryGetValue(typeID, out tm);
    }

    public bool TryGetGunTM(int typeID, out GunTM tm) {
        return gunTMs.TryGetValue(typeID, out tm);
    }

    public bool TryGetBulletTM(int typeID, out BulletTM tm) {
        return bulletTMs.TryGetValue(typeID, out tm);
    }

    public bool TryGetStuffTM(int typeID, out StuffTM tm) {
        return stuffTMs.TryGetValue(typeID, out tm);
    }

    public bool TryGetTerrainTM(int typeID, out TerrainTM tm) {
        return terrainTMs.TryGetValue(typeID, out tm);
    }

    public bool TryGetMapTM(int stageID, out MapTM tm) {
        return mapTMs.TryGetValue(stageID, out tm);
    }

    public bool TryGetPropTM(int typeID, out PropTM tm) {
        return propTMs.TryGetValue(typeID, out tm);
    }
}
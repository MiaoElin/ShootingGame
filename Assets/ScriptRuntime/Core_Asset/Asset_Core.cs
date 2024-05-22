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

    Dictionary<int, GunTM> gunTMs;
    AsyncOperationHandle gunTMPtr;

    Dictionary<int, StuffTM> stuffTMs;
    AsyncOperationHandle stuffPtr;

    Dictionary<int, TerrainTM> terrainTMs;
    AsyncOperationHandle terrainPtr;

    public ConfigTM configTM;
    AsyncOperationHandle configPtr;


    public AssetCore() {
        entities = new Dictionary<string, GameObject>();
        allUI_Prefab = new Dictionary<string, GameObject>();
        roleTMs = new Dictionary<int, RoleTM>();
        lootTMs = new Dictionary<int, LootTM>();
        gunTMs = new Dictionary<int, GunTM>();
        stuffTMs = new Dictionary<int, StuffTM>();
        terrainTMs = new Dictionary<int, TerrainTM>();
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
            var ptr = Addressables.LoadAssetsAsync<GunTM>("GunTM", null);
            gunTMPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                gunTMs.Add(tm.typeID, tm);
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

    }

    public void Unload() {
        if (entityPtr.IsValid()) {
            Addressables.Release(entityPtr);
        }
        if (roleTMPtr.IsValid()) {
            Addressables.Release(roleTMPtr);
        }
        if (uiPrefabPtr.IsValid()) {
            Addressables.Release(uiPrefabPtr);
        }
        if (configPtr.IsValid()) {
            Addressables.Release(configPtr);
        }
        if (lootTMPtr.IsValid()) {
            Addressables.Release(lootTMPtr);
        }
        if (gunTMPtr.IsValid()) {
            Addressables.Release(gunTMPtr);
        }
        if (stuffPtr.IsValid()) {
            Addressables.Release(stuffPtr);
        }
        if (terrainPtr.IsValid()) {
            Addressables.Release(terrainPtr);
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

    public bool TryGetStuffTM(int typeID, out StuffTM tm) {
        return stuffTMs.TryGetValue(typeID, out tm);
    }

    public bool TryGetTerrainTM(int typeID, out TerrainTM tm) {
        return terrainTMs.TryGetValue(typeID, out tm);
    }
}
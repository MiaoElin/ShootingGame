using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AssetCore {

    Dictionary<string, GameObject> entities;
    AsyncOperationHandle entityPtr;

    Dictionary<int, RoleTM> roleTMs;
    AsyncOperationHandle roleTMPtr;

    Dictionary<int, LootTM> lootTMs;
    AsyncOperationHandle lootTMPtr;

    Dictionary<string, GameObject> allUI_Prefab;
    public AsyncOperationHandle uiPrefabPtr;

    public ConfigTM configTM;
    AsyncOperationHandle configPtr;


    public AssetCore() {
        entities = new Dictionary<string, GameObject>();
        roleTMs = new Dictionary<int, RoleTM>();
        lootTMs = new Dictionary<int, LootTM>();
        allUI_Prefab = new Dictionary<string, GameObject>();
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
            var ptr = Addressables.LoadAssetsAsync<LootTM>("LootTM", null);
            lootTMPtr = ptr;
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                lootTMs.Add(tm.typeID, tm);
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

}
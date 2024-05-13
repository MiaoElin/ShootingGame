using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AssetCore {

    Dictionary<string, GameObject> entities;
    AsyncOperationHandle entityPtr;

    Dictionary<int, RoleTM> roleTMs;
    AsyncOperationHandle roleTMPtr;

    Dictionary<string, GameObject> allUI_Prefab;
    public AsyncOperationHandle uiPrefabPtr;


    public AssetCore() {
        entities = new Dictionary<string, GameObject>();
        roleTMs = new Dictionary<int, RoleTM>();
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
    }

    public bool TryGetEntity_Prefab(string name, out GameObject prefab) {
        return entities.TryGetValue(name, out prefab);
    }

    public bool TryGetRoleTM(int typeID, out RoleTM tm) {
        return roleTMs.TryGetValue(typeID, out tm);
    }

    public bool TrygeUI_Prefab(string name, out GameObject ui) {
        return allUI_Prefab.TryGetValue(name, out ui);
    }

}
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AssetCore {

    Dictionary<string, GameObject> entities;
    AsyncOperationHandle entityHandle;

    Dictionary<int, RoleTM> roleTMs;
    AsyncOperationHandle roleTMHandle;

    public AssetCore() {
        entities = new Dictionary<string, GameObject>();
        roleTMs = new Dictionary<int, RoleTM>();
    }

    public void LoadAll() {
        {
            var handle = Addressables.LoadAssetsAsync<GameObject>("Entities", null);
            entityHandle = handle;
            var list = handle.WaitForCompletion();
            foreach (var prefab in list) {
                entities.Add(prefab.name, prefab);
            }
        }
        {
            var handle = Addressables.LoadAssetsAsync<RoleTM>("RoleTM", null);
            roleTMHandle = handle;
            var list = handle.WaitForCompletion();
            foreach (var tm in list) {
                roleTMs.Add(tm.typeId, tm);
            }
        }
    }

    public void Unload() {
        if (entityHandle.IsValid()) {
            Addressables.Release(entityHandle);
        }
        if (roleTMHandle.IsValid()) {
            Addressables.Release(roleTMHandle);
        }
    }

    public bool TryGetEntity_Prefab(string name, out GameObject prefab) {
        return entities.TryGetValue(name, out prefab);
    }

    public bool TryGetRoleTM(int typeID, out RoleTM tm) {
        return roleTMs.TryGetValue(typeID, out tm);
    }
}
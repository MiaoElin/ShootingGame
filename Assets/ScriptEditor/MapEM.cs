using UnityEngine;
using UnityEditor;


public class MapEM : MonoBehaviour {
    public MapTM tm;

    [ContextMenu("Save")]
    public void Save() {
        // 把当前mapEM里的所有Em的信息，存到tm里对应的SpawnerTM里；
        {
            RoleEM[] roleEMs = GetComponentsInChildren<RoleEM>();
            if (roleEMs != null) {
                tm.roleSpawnerTMs = new RoleSpawnerTM[roleEMs.Length];
            }
            for (int i = 0; i < roleEMs.Length; i++) {
                var em = roleEMs[i];
                var spawnerTM = new RoleSpawnerTM();
                spawnerTM.roleTypeID = em.tm.typeId;
                spawnerTM.pos = em.transform.position;
                spawnerTM.rot = em.transform.eulerAngles;
                spawnerTM.scale = em.transform.localScale;
                tm.roleSpawnerTMs[i] = spawnerTM;

            }
        }

        {

        }
        EditorUtility.SetDirty(tm);

    }

    // void SetSpawnerTMs<T1, T2>(T1[] ems, T2[] spawnerTMs) {
    //     if (ems != null) {
    //         spawnerTMs = new T2[ems.Length];
    //     }
    //     for (int i = 0; i < ems.Length; i++) {
    //         var em = ems[i];
    //         var spawneTM = spawnerTMs[i];
    //         spawnerTMs.
    //     }

    // }
}
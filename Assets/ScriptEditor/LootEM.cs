using UnityEngine;

[ExecuteInEditMode]
public class LootEM : MonoBehaviour {

    public LootTM tm;
    public GameObject mod;

    void Awake() {
        if (mod == null) {
            mod = GameObject.Instantiate(tm.mod, transform);
            mod.transform.localPosition = Vector3.zero;
            mod.transform.localEulerAngles = Vector3.zero;
            mod.transform.localScale = Vector3.one;
        }
    }
}


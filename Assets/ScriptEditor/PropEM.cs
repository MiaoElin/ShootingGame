using UnityEngine;

[ExecuteInEditMode]
public class PropEM : MonoBehaviour {

    public PropTM propTM;
    public GameObject mod;
    void Awake() {
        if (mod == null) {
            mod = GameObject.Instantiate(propTM.mod, transform);
            mod.transform.localPosition = Vector3.zero;
            mod.transform.localEulerAngles = Vector3.zero;
            mod.transform.localScale = Vector3.one;
        }
    }
}
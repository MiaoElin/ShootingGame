using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RoleEM : MonoBehaviour {
    public RoleTM tm;
    public GameObject mod;
    void Awake() {
        if (mod == null) {
            mod = GameObject.Instantiate(tm.body, transform);
            mod.transform.localPosition = Vector3.zero;
            mod.transform.localEulerAngles = Vector3.zero;
        }
    }
}

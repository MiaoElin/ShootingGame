// #if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class LevelEditor : MonoBehaviour {

    [ContextMenu("Save Level")]
    public void Save() {
        Debug.Log("save");
    }
}
// #endif
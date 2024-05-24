using UnityEngine;

public class TerrainEntity : MonoBehaviour {

    public Vector3 gridPos;
    public Transform modTransform;

    public void Ctor(GameObject mod) {
        GameObject.Instantiate(mod, modTransform);
    }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }
}
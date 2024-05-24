using UnityEngine;

public class PropEntity : MonoBehaviour {
    public int typeId;
    public bool canBeDestory;
    public int id;
    public Transform modTransform;


    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    public void SetRotaion(Vector3 rot) {
        transform.eulerAngles = rot;
    }

    public void SetScale(Vector3 scale) {
        transform.localScale = scale;
    }
}
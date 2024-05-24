using UnityEngine;

[CreateAssetMenu(menuName = "TM/RoleTM", fileName = "RoleTM_")]
public class RoleTM : ScriptableObject {

    public int typeId;
    public int hpMax;
    public float height;
    public float moveSpeed;
    public float deadTimer;
    public MoveType moveType;
    public GameObject body;
    public float gravity;
    public float jumpingForce;
}
using UnityEngine;

[CreateAssetMenu(menuName = "TM/RoleTM", fileName = "RoleTM_")]
public class RoleTM : ScriptableObject {

    public int typeId;
    public int hpMax;
    public float height;
    public float walkSpeed;
    public float runSpeed;
    public float speedUpDuration;
    public float speedDownDuration;

    public float deadTimer;
    public MoveType moveType;
    public float viewRange;

    public GameObject body;
    public float gravity;
    public float jumpingForce;
}
using UnityEngine;

public class RoleEntity : MonoBehaviour {

    public int typeId;
    public int id;
    public int hp;
    public int hpMax;
    public float moveSpeed;
    public MoveType moveType;
    public Vector3 lastPos;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    public GameObject body;

    public void Ctor(Animator anim) {
        this.anim = anim;
    }

    public void Move(Vector3 moveAxis) {
        var velocity = rb.velocity;
        velocity = moveAxis.normalized * moveSpeed;
        rb.velocity = velocity;
        if (moveAxis != Vector3.zero) {
            SetForward(moveAxis);
        }
    }

    public void SetForward(Vector3 forward) {
        transform.forward = forward;
    }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    public void SetLastPos(Vector3 pos) {
        this.lastPos = pos;
    }

    public Vector3 GetPos() {
        return transform.position;
    }

    public Vector3 GetLastPos() {
        return lastPos;
    }

    public void Anim_Run() {
        anim.SetFloat("F_MoveSpeed", rb.velocity.magnitude);
    }


}
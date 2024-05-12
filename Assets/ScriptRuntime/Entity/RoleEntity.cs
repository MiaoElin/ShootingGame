using UnityEngine;

public class RoleEntity : MonoBehaviour {

    public int typeId;
    public int id;
    public int hp;
    public int hpMax;
    public float moveSpeed;
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
    }

    public void Anim_Run() {
        anim.SetFloat("F_MoveSpeed", rb.velocity.magnitude);
    }


}
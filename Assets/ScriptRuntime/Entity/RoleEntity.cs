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

    // Componet
    public GunComponent gunCom;

    // faceDir
    Vector3 startForward;
    Vector3 endForward;
    Vector3 oldForward;
    float timer;
    float duration;

    public RoleEntity() {
        gunCom = new GunComponent();
        timer = 0;
        duration = 0.5f;
    }

    public void Ctor(Animator anim) {
        this.anim = anim;
    }

    public void Move(Vector3 moveAxis, float dt) {

        var velocity = rb.velocity;
        velocity = moveAxis.normalized * moveSpeed;
        rb.velocity = velocity;

        if (moveAxis == Vector3.zero) {
            return;
        }
        // Update Forward
        Vector3 newForward = new Vector3(moveAxis.x, 0, moveAxis.z);
        if (newForward != oldForward) {
            startForward = oldForward;
            if (startForward == Vector3.zero) {
                startForward = transform.forward;
            }
            endForward = newForward;
            oldForward = newForward;
            timer = 0;
        }

        if (timer <= duration) {
            timer += dt;
            var quatStar = Quaternion.LookRotation(startForward);
            var quatEnd = Quaternion.LookRotation(endForward);
            transform.rotation = Quaternion.Lerp(quatStar, quatEnd, timer / duration);
        }
    }

    public void SetForward(Vector3 forward) {
        transform.forward = forward;
    }

    public Vector3 GetForward() {
        return transform.forward;
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
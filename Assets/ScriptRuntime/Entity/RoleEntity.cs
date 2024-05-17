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
    public Transform shootLookAt;

    // Componet
    public GunComponent gunCom;

    // faceDir;
    public float rotationSpeed;
    public Vector3 startForward;
    public Vector3 endForward;
    public Vector3 oldForward;
    public float time;
    public float duration;

    public RoleEntity() {
        gunCom = new GunComponent();
    }

    public void Ctor(Animator anim) {
        this.anim = anim;
        rotationSpeed = 7;
        duration = 0.25f;
    }

    public void Move(Vector3 moveAxis, float dt) {

        var velocity = rb.velocity;
        velocity = moveAxis.normalized * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        if (moveAxis == Vector3.zero) {
            return;
        }

        // // SetForward_Normal(moveAxis, dt);
        // SetForward_Shoot();
    }

    public void SetForward_Normal(Vector3 moveAxis, float dt) {
        // Update Forward
        if (moveAxis != Vector3.zero) {
            transform.forward = Vector3.Lerp(transform.forward, moveAxis.normalized, dt * rotationSpeed);
        }
    }

    public void SetForward_Shoot(Vector3 cameraPos) {
        var viewDir = shootLookAt.position - cameraPos;
        viewDir.y = 0;
        transform.forward = viewDir;
    }

    public void Jump() {

    }

    public void Falling() {

    }

    public float GetRotationY() {
        return transform.rotation.y;
    }

    public void SetForward(Vector3 forward) {
        body.transform.forward = forward;
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

    public void Anim_Jump() {
        anim.SetTrigger("T_Jump");
    }


}